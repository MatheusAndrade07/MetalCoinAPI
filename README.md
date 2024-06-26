## MetalCoin: Sua API para o Mundo das Moedas!

MetalCoin é uma API RESTful robusta e completa, desenvolvida em ASP.NET Core, para gerenciar moedas, fornecedores e categorias. Ela fornece uma plataforma poderosa para construir aplicações web e mobile que lidam com informações sobre moedas.

## Começando

### Pré-requisitos

- .NET 6 SDK: [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)
- SQL Server: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio: [https://visualstudio.microsoft.com/](https://visualstudio.microsoft.com/)

### Instalação

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/seu-usuario/metalcoin.git
   ```
2. **Configure a Conexão com o Banco de Dados:**
   - Abra o arquivo `appsettings.json` no projeto `MetalCoin.Api` e configure a string de conexão `DefaultConnection` com as credenciais do seu banco de dados SQL Server.
3. **Execute as Migrations:**
   - Abra o console do Package Manager Console no Visual Studio e navegue até o projeto `MetalCoin.Infra.Data`.
   - Execute o comando `Update-Database` para criar o banco de dados e as tabelas.
4. **Execute a Aplicação:**
   - Abra o projeto `MetalCoin.Api` no Visual Studio Code ou Visual Studio.
   - Execute a aplicação pressionando F5 ou usando o comando `dotnet run`.

### Documentação da API

A documentação da API está disponível através do Swagger. Acesse a URL `http://localhost:5000/swagger` (ou a porta que sua aplicação estiver utilizando) após iniciar a aplicação.

## Build e Testes

- **Build:** Para compilar a solução, execute o comando `dotnet build` na pasta raiz do projeto.
- **Testes:** O projeto inclui testes unitários. Para executá-los, use o comando `dotnet test` na pasta raiz do projeto.

## Contribuindo

Sinta-se à vontade para contribuir com o projeto MetalCoin! Você pode:

- Reportar bugs e problemas
- Sugerir novas funcionalidades
- Enviar pull requests com correções e melhorias

Antes de contribuir, leia o arquivo `CONTRIBUTING.md` para entender as diretrizes de contribuição.

## License

Este projeto está licenciado sob a licença MIT - consulte o arquivo `LICENSE.md` para obter detalhes.

## Contato

Se tiver alguma dúvida, entre em contato comigo em meu email: matheusandradepompermayer07@gmail.com

---
