import type { Person, CreatePersonRequest, PersonSummaryResponse } from "../types/person";
import api from "./api";

const PERSON_ENDPOINT = "/Person"

export async function getPersons(): Promise<Person[]> {
  return (await api.get<Person[]>(PERSON_ENDPOINT)).data;
}

export async function createPerson(person: CreatePersonRequest): Promise<Person> {
  return (await api.post<Person>(PERSON_ENDPOINT, person)).data;
}

export async function deletePerson(id: string): Promise<void> {
  await api.delete(`${PERSON_ENDPOINT}/${id}`);
}

export async function getSummary(): Promise<PersonSummaryResponse> {
  return (await api.get<PersonSummaryResponse>(`${PERSON_ENDPOINT}/summary`)).data;
}
