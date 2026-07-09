import { useState } from "react";
import type { PersonFormProps } from "../types/person";

export default function PersonForm({ onSubmit }: PersonFormProps) {
  const [name, setName] = useState("");
  const [age, setAge] = useState<number | "">("");
  const [submitted, setSubmitted] = useState(false)
  const [loading, setLoading] = useState(false)

  async function handleSubmit(e: React.FormEvent) {

    e.preventDefault();
    setSubmitted(true)

    if (!name.trim() || age === "" || age <= 0) {
      return;
    }

    setLoading(true)

    try {
      await onSubmit({
        name: name.trim(),
        age: Number(age),
      });

      setName("");
      setAge("");

    } catch (error) {
      console.log(error)
    } finally {
      setSubmitted(false)
      setLoading(false)
    }

  }

  return (
    <div className="mx-auto rounded-lg bg-white p-6 shadow pb-8 mb-6">
      <h2 className="mb-6 text-xl font-bold text-gray-800">
        Cadastro de Pessoa
      </h2>

      <form
        onSubmit={handleSubmit}
        className="flex items-end gap-4"
      >

        <div className="flex-1">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Nome
          </label>

          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Digite o nome"
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && name.trim() === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          />

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {submitted && name.trim() === "" && "O nome é obrigatório."}
          </p>
        </div>


        <div className="w-44">
          <label className="mb-1 block text-sm font-medium text-gray-700">
            Idade
          </label>

          <input
            type="number"
            value={age}
            min={0}
            onChange={(e) =>
              setAge(e.target.value === "" ? "" : Number(e.target.value))
            }
            placeholder="Idade"
            className={`w-full rounded px-3 py-2 focus:outline-none ${submitted && age === ""
              ? "border border-red-500 bg-red-50"
              : "border border-gray-300 focus:border-blue-500"
              }`}
          />

          <p className="mt-1 min-h-[20px] text-sm text-red-600">
            {(submitted && age === "" && "A idade é obrigatória.") || (submitted && age !== "" && age <= 0 && "A idade deve ser maior que zero.")}
          </p>
        </div>


        <button
          type="submit"
          disabled={loading}
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