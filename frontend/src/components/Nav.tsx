import { Link, NavLink } from "react-router-dom";

export default function Nav() {
  const active = ({ isActive }: { isActive: boolean }) =>
    isActive
      ? "text-blue-600 font-semibold"
      : "text-gray-600 hover:text-blue-600";

  return (
    <nav className="bg-white shadow-md border-b">
      <div className="mx-auto flex h-16 max-w-7xl items-center justify-between px-6">
        <Link
          to="/"
          className="text-2xl font-bold text-blue-600"
        >
          Finanças
        </Link>

        <div className="flex gap-8">
          <NavLink to="/" className={active} end>
            Pessoas
          </NavLink>

          <NavLink to="/transactions" className={active}>
            Transações
          </NavLink>

          <NavLink to="/summary" className={active}>
            Totais
          </NavLink>
        </div>
      </div>
    </nav>
  );
}