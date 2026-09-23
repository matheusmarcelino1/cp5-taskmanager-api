# TaskManager API

API RESTful desenvolvida em C# com ASP.NET Core .NET 10 e Entity Framework Core para gerenciamento de tarefas.

## Integrantes

* Matheus Marcelino Dantas da Silva — RM556332
* Adicionar integrante — RM
* Adicionar integrante — RM

## Contexto do Projeto

O TaskManager é uma API RESTful desenvolvida para realizar o gerenciamento de tarefas.

A aplicação permite cadastrar, consultar, atualizar e excluir tarefas, possibilitando o controle de informações como título, descrição, status de conclusão e data de criação.

O projeto é destinado a usuários ou sistemas que necessitem de uma solução simples para organização e acompanhamento de tarefas.

## Tecnologias Utilizadas

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger / OpenAPI

## Banco de Dados

O projeto utiliza **SQLite** como banco de dados.

A persistência dos dados é realizada utilizando **Entity Framework Core**, com migrations para criação e atualização da estrutura do banco.

A migration inicial do projeto é:

`InitialCreate`

## Como executar o projeto

### Pré-requisitos

* .NET 10 SDK
* Visual Studio 2026 ou outra IDE compatível com .NET 10
* Git

### 1. Clone o repositório

```bash
git clone URL_DO_REPOSITORIO
```

### 2. Acesse a pasta do projeto

```bash
cd TaskManager.Api
```

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Aplique as migrations

```bash
dotnet ef database update
```

Caso a ferramenta `dotnet-ef` não esteja instalada:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Execute a aplicação

```bash
dotnet run
```

### 6. Acesse o Swagger

Com a aplicação em execução, acesse a URL `/swagger` apresentada pela aplicação.

Exemplo:

```text
https://localhost:PORTA/swagger
```

## Endpoints

| Método | Endpoint               | Descrição                     | Status principais |
| ------ | ---------------------- | ----------------------------- | ----------------- |
| GET    | `/api/v1/tarefas`      | Lista todas as tarefas        | 200               |
| GET    | `/api/v1/tarefas/{id}` | Busca uma tarefa pelo ID      | 200, 404          |
| POST   | `/api/v1/tarefas`      | Cadastra uma nova tarefa      | 201, 400          |
| PUT    | `/api/v1/tarefas/{id}` | Atualiza uma tarefa existente | 200, 400, 404     |
| DELETE | `/api/v1/tarefas/{id}` | Exclui uma tarefa             | 204, 404          |

## Exemplos de Requisições

### POST `/api/v1/tarefas`

```json
{
  "titulo": "Finalizar Checkpoint",
  "descricao": "Finalizar e entregar o projeto CP5"
}
```

### PUT `/api/v1/tarefas/1`

```json
{
  "titulo": "Finalizar Checkpoint",
  "descricao": "Finalizar e entregar o projeto CP5",
  "concluida": true
}
```

## Versionamento

A API utiliza versionamento através da URL.

A versão atual é a **v1**:

```text
/api/v1/tarefas
```

## Evidências de Testes

As evidências dos testes realizados através do Swagger estão disponíveis na pasta `Evidencias`.

Foram testados os seguintes cenários:

* GET de todas as tarefas — 200 OK
* GET de tarefa por ID — 200 OK
* GET com ID inexistente — 404 Not Found
* POST de tarefa — 201 Created
* POST com dados inválidos — 400 Bad Request
* PUT de tarefa — 200 OK
* DELETE de tarefa — 204 No Content
