## 🐳 Executando o projeto com Docker

O projeto utiliza **Docker Compose** para subir os seguintes serviços:

- PostgreSQL 16
- pgAdmin 4
- Frontend React (Vite)

### Subindo os containers

Na raiz do projeto execute:

```bash
docker compose up -d
```

Verifique se os containers estão em execução:

```bash
docker ps
```

### Serviços disponíveis

| Serviço | URL | Credenciais |
|---------|-----|-------------|
| React | http://localhost:5173 | - |
| pgAdmin | http://localhost:5050 | admin@admin.com / admin |
| PostgreSQL | localhost:5432 | postgres / postgres |

### Banco de dados

| Configuração | Valor |
|--------------|-------|
| Database | finance_db |
| Usuário | postgres |
| Senha | postgres |
| Porta | 5432 |

---

## ⚙️ Configuração da API

Configure a connection string em:

```text
backend/financas.Api/appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=finance_db;Username=postgres;Password=postgres"
  }
}
```

---

## 🗄️ Aplicando as Migrations

Entre na pasta do backend:

```bash
cd backend
```

Execute:
- Baixa e restaura os pacotes NuGet do projeto:
```bash
dotnet restore
```
- Execute as migrations:
```bash
dotnet ef database update
```

---

## ▶️ Executando a API

Ainda na pasta `backend`:

```bash
dotnet run
```

A API ficará disponível em:

http://localhost:5161

Já esta configurado para abrir diretamente o Swagger
---

## 🚀 Acessar o projeto completo

<!-- 1. Suba os containers:

```bash
docker compose up -d
```

2. Execute as migrations:

```bash
cd backend
dotnet ef database update
```

3. Execute a API:

```bash
dotnet run
``` -->

Acesse:

- Frontend: http://localhost:5173
- Swagger: http://localhost:5161
- pgAdmin: http://localhost:5050