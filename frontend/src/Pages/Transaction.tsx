import { useEffect, useState } from "react";
import TransactionTable from "../components/TransactionTable";
import TransactionForm from "../components/TransactionForm";
import { createTransaction, getTransactions } from "../services/transaction.service";
import type { CreateTransactionRequest, Transaction } from "../types/transaction";
import { alert } from "../utils/alert";

export default function Transaction() {

  const [transactions, setTransactions] = useState<Transaction[]>([])

  async function loadTransactions() {
    try {
      const data = await getTransactions()
      setTransactions(data)
    } catch (error) {
      alert.error("Erro ao carregar transações.")
    }
  }

  async function handleCreate(transaction: CreateTransactionRequest) {
    try {
      await createTransaction(transaction)
      alert.success("Transação Cadastrada com Sucesso!")
      await loadTransactions()

    } catch (error: unknown) {
      const message = error instanceof Error ? error.message : "Erro ao cadastrar"
      alert.error(message)
    }
  }

  useEffect(() => {
    void loadTransactions()
  }, [])
  return (
    <>
      <div className="space-y-6">
        <TransactionForm onSubmit={handleCreate} />
        <TransactionTable transactions={transactions} />
      </div>
    </>
  );
}