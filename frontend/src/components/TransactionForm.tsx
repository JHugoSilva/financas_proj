import { useEffect, useState } from "react";
import type { Person } from "../types/person";
import { getPersons } from "../services/person.service";
import type { TransactionFormProps, TransactionType } from "../types/transaction";
import { alert } from "../utils/alert";

export default function TransactionForm({ onSubmit }: TransactionFormProps) {
  const [description, setDescription] = useState("");
  const [amount, setAmount] = useState<number | "">("");
  const [type, setType] = useState<TransactionType | "">("");
  const [personId, setPersonId] = useState("");
  const [persons, setPersons] = useState<Person[]>([]);
  const [submitted, setSubmitted] = useState(false)
  const [loading, setLoading] = useState(false)

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setSubmitted(true)

    if (!description || amount == "" || !type || !personId) {
      return
    }

    setLoading(true)
    try {

      await onSubmit({
        description,
        amount: Number(amount),
        type,
        personId,
      })

      setDescription("")
      setAmount("")
      setType("")
      setPersonId("")

    } catch (error) {
      console.log(error)
    } finally {
      setSubmitted(false)
      setLoading(false)
    }

  }

  const loadPersons = async () => {
    try {
      const response = await getPersons()
      setPersons(response)
    } catch (error) {
      alert.error("Erro ao carregar pessoas")
    }
  }

  useEffect(() => {
    void loadPersons()
  }, [])

  return (
    <div className="mx-auto rounded-lg bg-white p-6 shadow pb-8 mb-6">
      <h2 className="mb-6 text-xl font-bold text-gray-800">
        Cadastro de Movimentações
      </h2>

      <form
        onSubmit={
          handleSubmit
        }
        className="flex items-end gap-4"
      >

        <div className="flex-1">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Descrição
          </label>

          <input
            type="text"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            placeholder="Descrição da transação"
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && description.trim() === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          />

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {submitted && description.trim() === "" &&
              "A descrição é obrigatória."}
          </p>
        </div>

        <div className="w-44">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Valor
          </label>

          <input
            type="number"
            step="0.01"
            value={amount}
            onChange={(e) =>
              setAmount(e.target.value === "" ? "" : Number(e.target.value))
            }
            placeholder="0,00"
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && amount === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          />

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {submitted && amount === "" && "O valor é obrigatório."}
          </p>
        </div>

        <div className="w-52">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Tipo
          </label>

          <select
            value={type}
            onChange={(e) => setType(e.target.value as TransactionType | "")}
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && type === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          >
            <option value="">Selecione</option>
            <option value="Income">Receita</option>
            <option value="Expense">Despesa</option>
          </select>

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {submitted && type === "" && "Selecione um tipo."}
          </p>
        </div>

        <div className="w-72">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Pessoa
          </label>

          <select
            value={personId}
            onChange={(e) => setPersonId(e.target.value)}
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && personId === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          >
            <option value="">Selecione uma pessoa</option>

            {persons.map((person) => (
              <option key={person.id} value={person.id}>
                {person.name}
              </option>
            ))}
          </select>

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {submitted && personId === "" && "Selecione uma pessoa."}
          </p>
        </div>

        <button
          type="submit"
          className="rounded mb-6 bg-blue-600 px-6 py-2 font-semibold text-white
                 hover:bg-blue-700 cursor-pointer"
        >
          {
            loading ? "Cadastrando..." : "Cadastrar"
          }
        </button>

      </form>
    </div>
  );
}