import { useEffect, useState } from "react";
import type { PersonSummaryResponse } from "../types/person";
import { getSummary } from "../services/person.service";
import SummaryTable from "../components/SummaryTable";
import { alert } from "../utils/alert";

export default function PersonSummary() {

  const [summary, setSummary] = useState<PersonSummaryResponse | null>(null)

  async function loadSummary() {
    try {
      const data = await getSummary()
      setSummary(data)
    } catch (error) {
      alert.error("Erro ao carregar o resumo")
    }
  }

  useEffect(() => {
    void loadSummary()
  }, [])
  return (
    <div className="space-y-6">
      <SummaryTable summary={summary} />
    </div>
  );
}