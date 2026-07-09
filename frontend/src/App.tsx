import { Routes, Route } from "react-router-dom";
import Nav from "./components/Nav";
import Person from "./Pages/Person";
import Transaction from "./Pages/Transaction";
import Summary from "./Pages/PersonSummary";

function App() {
  return (
    <div className="min-h-screen bg-gray-100">
      <Nav />
      <main className="mx-auto max-w-7xl p-6">
        <Routes>
          <Route path="/" element={<Person />} />
          <Route path="/transactions" element={<Transaction />} />
          <Route path="/summary" element={<Summary />} />
        </Routes>
      </main>
    </div>
  );
}

export default App;