# AutoresCRUD - API de Gerenciamento de Autores

Esta é uma API RESTful desenvolvida em .NET para o gerenciamento completo de autores. O projeto foi construído focando em boas práticas de desenvolvimento, escalabilidade e performance.

##  Tecnologias Utilizadas

*   **.NET 10**
*   **ASP.NET Core Web API**
*   **Entity Framework Core**
*   **DTOs (Data Transfer Objects)**
*   **PostgreSQL** para banco de dados.
*   **Programação Assíncrona** com suporte a cancelamento de requisições (`CancellationToken`).

##  Arquitetura e Organização

O projeto segue uma estrutura organizada para facilitar a manutenção:

- **Controllers:** Camada de entrada que gerencia as rotas e requisições HTTP.
- **Services:** Camada de lógica de negócio, onde residem as regras da aplicação.
- **Models:** Representação das entidades do banco de dados.
- **Dtos:** Objetos de transferência para entrada e saída de dados, evitando a exposição direta dos modelos.
- **ResponseModel:** Wrapper genérico para padronização das respostas da API.


## OpenAPI (Scalar)
Pode ser acessado com: /scalar/v1
(Padrão ao rodar a aplicação)
##  Endpoints Disponíveis

### Autores
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/Autor/listar-autores` | Lista todos os autores cadastrados. |
| `GET` | `/api/Autor/buscar-autor-por-id/{id}` | Busca um autor específico pelo seu ID. |
| `GET` | `/api/Autor/buscar-autor-por-id-livro/{id}` | Retorna o autor associado a um determinado ID de livro. |
| `POST` | `/api/Autor/criar-autor` | Cadastra um novo autor no sistema. |
| `PUT` | `/api/Autor/editar-autor/{id}` | Atualiza os dados de um autor existente. |
| `DELETE` | `/api/Autor/excluir-autor/{id}` | Remove um autor do sistema. |

### Livros
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/Livro/listar-livros` | Lista todos os livros cadastrados. |
| `GET` | `/api/Livro/buscar-livro-por-id/{id}` | Busca um livro específico pelo seu ID. |
| `GET` | `/api/Livro/buscar-livro-por-id-autor/{id}` | Retorna os livros associados a um determinado ID de autor. |
| `POST` | `/api/Livro/criar-livro` | Cadastra um novo livro no sistema. |
| `PUT` | `/api/Livro/editar-livro/{id}` | Atualiza os dados de um livro existente. |
| `DELETE` | `/api/Livro/excluir-livro/{id}` | Remove um livro do sistema. |

## Como executar o projeto

1.  Certifique-se de ter o **SDK do .NET** instalado.
2.  Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/AutoresCRUD.git
    ```
3.  Restaure as dependências:
    ```bash
    dotnet restore
    ```
4.  Atualize a string de conexão no `appsettings.json` (se necessário).
5.  Execute as migrations para criar o banco de dados:
    ```bash
    dotnet ef database update
    ```
6.  Inicie a aplicação:
    ```bash
    dotnet run
    ```