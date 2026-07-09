interface PersonBase {
  name: string;
  age: number;
}

export interface Person extends PersonBase {
  id: string;
}

export type CreatePersonRequest = PersonBase

export interface PersonSummary extends Person {
  receitas: number;
  despesas: number;
  saldo: number;
}

export interface PersonSummaryResponse {
  persons: PersonSummary[];
  totalReceitas: number;
  totalDespesas: number;
  totalSaldo: number;
}

export interface PersonTableProps {
  people: Person[];
  onDelete: (id: string) => void;
}

export interface PersonFormProps {
  onSubmit: (person: CreatePersonRequest) => Promise<void>
}

export type SummaryTableProps = {
  summary: PersonSummaryResponse | null;
};