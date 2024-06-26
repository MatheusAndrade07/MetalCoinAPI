
##Nuget Package

No projeto de infraestrutura, instale os seguintes pacotes nuget:
Obs: sempre verifique a se a versão é compatível com a versão do .net core que você está utilizando.
```bash
//Instalando o pacote do Entity Framework no Infra
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Relational
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

//Instalando o pacote do Entity Framework na Api
Microsoft.EntityFrameworkCore.Design

```

No projeto de api vamos configurar a string conexão com o banco de dados, para isso, abra o arquivo appsettings.json 
e adicione a string de conexão com o banco de dados.
```bash
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ConnectionStrings": {
    "SqlServer": "Server=localhost;Database=MetalCoin;User Id=sa;Password=Password123;Trusted_Connection=true;MultipleActiveResultSet=true"
  }
```

##Criando o contexto do banco de dados
```bash
Comandos para criar o banco de dados
``` Add-Migration InitialCreate
``` Update-Database
```bash