import type { TransactionTableProps } from "../types/transaction";


export default function TransactionTable({
  transactions,
}: TransactionTableProps) {
  return (
    <div className="overflow-hidden rounded-lg bg-white shadow">

      <div className="border-b p-4">
        <h2 className="text-xl font-bold text-gray-800">
          Transações cadastradas
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
                Descrição
              </th>

              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Valor
              </th>

              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Tipo
              </th>

              <th className="px-6 py-3 text-left text-sm font-semibold text-gray-700">
                Nome (Pessoa)
              </th>
            </tr>

          </thead>


          <tbody>

            {transactions.length === 0 ? (

              <tr>
                <td
                  colSpan={5}
                  className="px-6 py-4 text-center text-gray-500"
                >
                  Nenhuma transação cadastrada
                </td>
              </tr>

            ) : (

              transactions.map((t) => (

                <tr
                  key={t.id}
                  className="border-t hover:bg-gray-50"
                >

                  <td className="px-6 py-3 text-sm">
                    {t.id.slice(0, 8)}
                  </td>


                  <td className="px-6 py-3 text-sm">
                    {t.description}
                  </td>


                  <td className="px-6 py-3 text-sm">
                    {t.amount}
                  </td>

                  <td className={`px-6 py-3 text-sm font-medium ${t.type === "Income" ? "text-green-600" : "text-red-600"
                    }`}>
                    {t.type === "Income" ? "Receita" : "Despesa"}
                  </td>

                  <td className="px-6 py-3 text-sm">
                    {t.person.name}
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