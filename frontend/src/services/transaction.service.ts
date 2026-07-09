import type { CreateTransactionRequest, Transaction } from "../types/transaction";
import api from "./api";

const TRANSACTION_ENDPOINT = "/Transaction"

export async function getTransactions(): Promise<Transaction[]> {
  return (await api.get<Transaction[]>(TRANSACTION_ENDPOINT)).data;
}

export async function getTransaction(id: string): Promise<Transaction> {
  return (await api.get<Transaction>(`${TRANSACTION_ENDPOINT}/${id}`)).data;
}

export async function createTransaction(
  transaction: CreateTransactionRequest
): Promise<Transaction> {
  return (await api.post<Transaction>(
    TRANSACTION_ENDPOINT,
    transaction
  )).data;

}

export async function deleteTransaction(id: string): Promise<void> {
  await api.delete(`${TRANSACTION_ENDPOINT}/${id}`);
}