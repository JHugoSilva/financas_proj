import { useEffect, useState } from "react";
import PersonTable from "../components/PersonTable";
import PersonForm from "../components/PersonForm";
import { createPerson, deletePerson, getPersons } from "../services/person.service";
import type { CreatePersonRequest, Person } from "../types/person";
import { alert } from "../utils/alert";

export default function Person() {

  const [people, setPeople] = useState<Person[]>([])

  async function loadPersons() {
    try {
      const data = await getPersons()
      setPeople(data)
    } catch (error) {
      alert.error("Erro ao carregar pessoas.")
    }
  }

  async function handleCreate(person: CreatePersonRequest) {
    try {
      const newPerson = await createPerson(person)
      alert.success("Pessoa Cadastrada com Sucesso!")
      setPeople((prev) => [...prev, newPerson])
    } catch (error: unknown) {
      alert.error(
        error instanceof Error ? error.message : "Erro ao cadastrar pessoa."
      );
    }
  }

  async function handleDelete(id: string) {
    try {
      const confirm = await alert.confirm("Deseja excluir esta pessoa?")
      console.log(confirm)
      if (!confirm) {
        return
      }
      await deletePerson(id)
      setPeople((prev) => prev.filter((p) => p.id != id))
      await alert.success("Pessoa excluída com sucesso!")
    } catch (error: unknown) {
      alert.error(
        error instanceof Error ? error.message : "Erro ao remover pessoa."
      );
    }
  }

  useEffect(() => {
    void loadPersons()
  }, [])
  return (
    <div className="space-y-6">
      <PersonForm onSubmit={handleCreate} />
      <PersonTable people={people} onDelete={handleDelete} />
    </div>
  );
}