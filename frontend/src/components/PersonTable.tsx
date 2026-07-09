import type { PersonTableProps } from "../types/person";

export default function PersonTable({
  people,
  onDelete,
}: PersonTableProps) {
  return (
    <div className="overflow-hidden rounded-lg bg-white shadow">

      <div className="border-b p-4">
        <h2 className="text-xl font-bold text-gray-800">
          Pessoas cadastradas
        </h2>
      </div>


      <div className="overflow-x-auto">

        <table className="w-full">

          <thead className="bg-gray-100">

            <tr>
              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Identificador
              </th>

              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Nome
              </th>

              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Idade
              </th>

              <th className="px-6 py-3 text-center text-sm font-semibold text-gray-700">
                Ações
              </th>
            </tr>

          </thead>


          <tbody>

            {people.length === 0 ? (

              <tr>
                <td
                  colSpan={4}
                  className="px-6 py-4 text-center text-gray-500"
                >
                  Nenhuma pessoa cadastrada
                </td>
              </tr>

            ) : (

              people.map((person) => (

                <tr
                  key={person.id}
                  className="border-t hover:bg-gray-50"
                >

                  <td className="px-6 py-3 text-sm">
                    {person.id.slice(0, 8)}
                  </td>


                  <td className="px-6 py-3 text-sm">
                    {person.name}
                  </td>


                  <td className="px-6 py-3 text-sm">
                    {person.age}
                  </td>


                  <td className="px-6 py-3 text-center">

                    <button
                      type="button"
                      onClick={() => onDelete(person.id)}
                      className="rounded bg-red-600 px-3 py-1 text-sm text-white hover:bg-red-700"
                    >
                      Excluir
                    </button>

                  </td>

                </tr>

              ))

            )}

          </tbody>

        </table>

      </div>

    </div>
  );
}