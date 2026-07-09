## 🐳 Executando o banco de dados com Docker

Caso não tenha o PostgreSQL instalado, execute o container abaixo.

### docker-compose.yml

```yaml
services:
  postgres:
    image: postgres:16
    container_name: postgres-db
    restart: unless-stopped

    environment:
      POSTGRES_DB: finance_db
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres

    ports:
      - "5432:5432"

    volumes:
      - postgres_data:/var/lib/postgresql/data

volumes:
  postgres_data:
```

Inicie o banco:

```bash
docker compose up -d
```

Verifique se o container está em execução:

```bash
docker ps
```

---

## ⚙️ Configuração da API

Edite o arquivo:

```text
backend/financas.Api/appsettings.json
```

Configure a conexão com o banco:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=finance_db;Username=postgres;Password=postgres"
  }
}
```

---

## 🗄️ Executando as Migrations

Dentro da pasta **backend** execute:

```bash
cd backend
```

Aplicar as migrations:

```bash
dotnet ef database update
```

Caso ainda não existam migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ▶️ Executando a API

Entre na pasta do backend:

```bash
cd backend
```

Execute:

```bash
dotnet run --project financas.Api
```

A API ficará disponível em:

```text
https://localhost:5001
```

ou

```text
http://localhost:5000
```

Swagger:

```text
https://localhost:5001/swagger
```

---

# ⚛️ Front-end React

Entre na pasta do frontend:

```bash
cd frontend
```

Instale as dependências:

```bash
npm install
```

Execute a aplicação:

```bash
npm run dev
```

O React ficará disponível em:

```text
http://localhost:5173
```

---

## 📂 Estrutura do projeto

```text
projeto
├── backend
│   ├── financas.Api
│   ├── financas.Application
│   ├── financas.Domain
│   └── financas.Infrastructure
│
├── frontend
│   ├── src
│   ├── public
│   ├── package.json
│   └── vite.config.ts
│
├── docker-compose.yml
└── README.md
```

---

## 🚀 Executando o projeto completo

### 1. Suba o PostgreSQL

```bash
docker compose up -d
```

### 2. Execute as migrations

```bash
cd backend
dotnet ef database update
```

### 3. Execute a API

```bash
dotnet run --project financas.Api
```

### 4. Execute o Front-end

Em outro terminal:

```bash
cd frontend
npm install
npm run dev
```

Agora acesse:

- **Frontend:** http://localhost:5173
- **API:** http://localhost:5000
- **Swagger:** http://localhost:5000/swagger# financas_proj
