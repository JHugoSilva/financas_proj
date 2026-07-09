import type { Person } from "./person";

export type TransactionType = "Income" | "Expense";

interface TransactionBase {
  amount: number;
  description: string;
  personId: string;
  type: TransactionType;
}

export interface Transaction extends TransactionBase {
  id: string;
  person: Person;
};

export interface TransactionFormProps {
  onSubmit: (transaction: CreateTransactionRequest) => void | Promise<void>
}

export interface TransactionTableProps {
  transactions: Transaction[];
}

export type CreateTransactionRequest = TransactionBase;
