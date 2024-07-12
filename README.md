# Creatus
Este projeto é uma API desenvolvida em ASP.NET Core para gerenciar usuários. Ele oferece operações básicas de CRUD (Create, Read, Update, Delete) para manipulação de usuários no sistema.

## Visão Geral
Este projeto fornece uma API RESTful para realizar operações de CRUD em usuários. Cada usuário possui atributos como ID, nome, email e nível de acesso. A API é protegida por autenticação JWT (JSON Web Token) para garantir a segurança das operações sensíveis.

## Funcionalidades
- Registro de novos usuários com validação de campos obrigatórios.
- Login de usuários com geração de token JWT para autenticação.
- Listagem, consulta detalhada, atualização e exclusão de usuários.
- Proteção de rotas e operações sensíveis por autenticação JWT.
- Rota privada para geração de relatórios em PDF contendo informações de usuários com nível de acesso >= 4.

## Instalação
Para executar este projeto localmente, siga os passos abaixo:

1. Clone o repositório:
   ```bash
   git clone https://github.com/Iewandowski/Creatus-Backend.git
2. Navegue até o diretório do projeto:
     ```bash
      cd .\Creatus-Backend\
3. Instale as dependências:
   ```bash
      dotnet restore
4. Execute as migrações do banco de dados:
   ```bash
      dotnet ef database update
5. Inicie o servidor de desenvolvimento:
   ```bash
      dotnet run
*A documentação swagger estará disponível em http://localhost:5240/swagger/index.html*
