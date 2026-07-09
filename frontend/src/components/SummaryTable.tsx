import type { SummaryTableProps } from "../types/person";

export default function SummaryTable({
  summary,
}: SummaryTableProps) {
  return (
    <div className="overflow-hidden rounded-lg bg-white shadow">

      <div className="border-b p-4">
        <h2 className="text-xl font-bold text-gray-800">
          Resumo Financeiro
        </h2>
        <div className="mt-4 grid grid-cols-1 gap-4 md:grid-cols-3">
          <div className="rounded-lg bg-green-50 p-4 border border-green-200">
            <p className="text-sm text-gray-600">Total de Receitas</p>
            <p className="text-2xl font-bold text-green-600">
              R$ {summary?.totalReceitas.toFixed(2)}
            </p>
          </div>

          <div className="rounded-lg bg-red-50 p-4 border border-red-200">
            <p className="text-sm text-gray-600">Total de Despesas</p>
            <p className="text-2xl font-bold text-red-600">
              R$ {summary?.totalDespesas.toFixed(2)}
            </p>
          </div>

          <div className="rounded-lg bg-blue-50 p-4 border border-blue-200">
            <p className="text-sm text-gray-600">Saldo Total</p>
            <p
              className={`text-2xl font-bold ${(summary?.totalSaldo ?? 0) >= 0
                ? "text-blue-600"
                : "text-red-600"
                }`}
            >
              R$ {summary?.totalSaldo.toFixed(2)}
            </p>
          </div>
        </div>
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
                Receita
              </th>

              <th className="px-6 py-3 text-center text-sm font-semibold text-gray-700">
                Despesa
              </th>


              <th className="px-6 py-3 text-center text-sm font-semibold text-gray-700">
                Saldo
              </th>
            </tr>

          </thead>


          <tbody>

            {summary?.persons.length === 0 ? (

              <tr>
                <td
                  colSpan={6}
                  className="px-6 py-4 text-center text-gray-500"
                >
                  Nenhum Resumo cadastrado
                </td>
              </tr>

            ) : (

              summary?.persons.map((person) => (

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
                    <p className="text-sm font-bold text-green-600">
                      R$ {person.receitas.toFixed(2)}
                    </p>
                  </td>

                  <td className="px-6 py-3 text-center">
                    <p className="text-sm font-bold text-red-600">
                      R$ {person.despesas.toFixed(2)}
                    </p>
                  </td>

                  <td className="px-6 py-3 text-center">
                    <p
                      className={`text-sm font-bold ${(person?.saldo ?? 0) >= 0
                        ? "text-blue-600"
                        : "text-red-600"
                        }`}
                    >

                      R$ {person.saldo.toFixed(2)}
                    </p>

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