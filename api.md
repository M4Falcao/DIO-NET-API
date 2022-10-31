# Introdução as APIs com C#

> dotnet new webapi
> dotnet watch run

Entity Framework
O EF é um framework ORM(Objectrelational mapping) criado para facilitar a integração com o banco de dados baseado em SQL.

No sistema
> dotnet tool install --global dotnet-ef


No projeto
> dotnet add package Microsoft.EntityFrameworkCore.Design

> dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Como fazer:
- Cria a classe

- Cria o contexto

´´´
public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { } 

public DbSet<Contato> Contatos { get; set; } 
´´´

- Altera o appsetings.Dev.json
```
,
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost\\sqlexpress; Initial Catalog=Agenda; Integrated Security=True"
  }
```

- Criar as Migrations
> dotnet-ef migrations add CriacaoTabelaContato

Comando para atualizar o bando de dados
> dotnet-ef database update

- Criar a controller 
```
 private readonly AgendaContext _context;
public ContatoController(AgendaContext context)
{
    _context = context;
}
       
```

- Alterar a program.cs
```
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
```

OBS:

Put -> Tem q passar tudo
Patch -> Atualização parcial, pode passar só uma informação