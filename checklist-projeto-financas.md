# 💰 Finanças API

API para gerenciamento financeiro pessoal, permitindo cadastro de pessoas e controle de transações (receitas e despesas).

## 🚀 Tecnologias utilizadas

- .NET 8 / ASP.NET Core
- Entity Framework Core
- PostgreSQL
- C#
- REST API
- Swagger/OpenAPI
- Docker (opcional)

## 📁 Estrutura do projeto
```text
financas
│
├── financas.Api # Camada da API (Controllers)
│
├── financas.Application # Regras de negócio, DTOs e Services
│
├── financas.Domain # Entidades e Enums
│
└── financas.Infrastructure # Banco de dados e Repositories
```

## ⚙️ Requisitos

Antes de executar o projeto, tenha instalado:

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- PostgreSQL
- Git

Verifique:

```bash
dotnet --version
```
📥 Clonar o projeto
```bash
git clone https://github.com/seu-usuario/financas.git
```
Entre na pasta:
```bash
cd financas
```
🗄️ Configuração do banco de dados

Configure a connection string em:
```bash
financas.Api/appsettings.json
```
Exemplo:
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=financas;Username=postgres;Password=postgres"
  }
}
```
🏗️ Criar o banco usando migrations

Execute:
```bash
dotnet ef database update
```
Caso não tenha o EF instalado:
```bash
dotnet ef migrations add InitialCreate  
```
▶️ Executando o projeto

Entre na pasta da API:
```bash
cd financas.Api  
```
Execute:
```bash
dotnet run
```
A API estará disponível em:
```bash
https://localhost:xxxx
```
📚 Swagger

Após iniciar a aplicação, acesse:
```bash
https://localhost:xxxx/swagger
```
🔥 Endpoints
Pessoas
Criar pessoa
```bash
POST /api/person
```
Exemplo:
```bash
{
  "name": "João",
  "age": 30
}
```
Listar pessoas
```bash
GET /api/person
```
Buscar pessoa por ID
```bash
GET /api/person/{id}
```
Atualizar pessoa
```bash
PUT /api/person/{id}
```
Remover pessoa
```bash
DELETE /api/person/{id}
```
_________________________________________________________________________________________________________________________
💳 Transações
Criar transação
```bash
POST /api/transaction
```
Exemplo:
```bash
{
  "amount": 2500,
  "description": "Salário",
  "personId": "guid-da-pessoa",
  "type": "Income"
}
```
- Tipos:
- Income  = Receita
- Expense = Despesa

Buscar transação
```bash
GET /api/transaction/{id}
```
Listar transações
```bash
GET /api/transaction
```
______________________________________________________________________________________________________
📊 Resumo financeiro

Endpoint:
```bash
GET /api/person/summary
```
Retorna:

- Receitas por pessoa
- Despesas por pessoa
- Saldo total

🧪 Testes

Executar testes:
```bash
dotnet test
```
📝 Regras de negócio
- Pessoas menores de 18 anos não podem cadastrar receitas.
- Apenas despesas são permitidas para menores de idade.
- Valores financeiros utilizam decimal.
- Transações sempre pertencem a uma pessoa existente.
📄 Licença

Este projeto está sob a licença MIT.
