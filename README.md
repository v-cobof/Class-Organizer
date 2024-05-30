# ClassOrganizer

Este projeto permite o cadastro de Alunos, Turmas e o relacionamento entre ambos.

## Executando o projeto

Para executar o projeto é necessário ter:

- .NET 8
- SQL Server

Primeiro você deve clonar o projeto do Github para sua máquina, e então executar o 'script.sql' que está dentro da pasta 'sql'. Ele vai criar o banco de dados.

Com o projeto restaurado, altere a connectionString para conectar ao seu SQL Server. Ela pode ser encontrada no arquivo 'appsettings.Development.json', com o nome 'DefaultConnection'. 

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/a2a79dbb-2570-4661-80aa-634243230798)

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/4300e79e-2bd5-40ee-b988-ddf724c508cc)

Nesse caso o valor da connectionString é

`Server=(localdb)\\mssqllocaldb;Database=ClassOrganizerDb;Trusted_Connection=True;MultipleActiveResultSets=true`

Mas você deve substituir para a connectionString que conecte ao seu banco de dados.

Os projetos a serem executados são a API com nome 'ClassOrganizer.API' e a interface com nome 'ClassOrganizer.Web'.

Para executar ambos os projetos no Visual Studio você pode configurar multiplos projetos de startup da seguinte maneira:

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/2672e22a-5823-459d-baf8-a187520b5242)

Também é possível executar cada um entrando em sua pasta e digitando na linha de comando

`dotnet run`

Além das mensagens de warning, o seguinte será escrito no console:

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/b575c1c3-d9cf-4ac2-a9ac-44e7339ad674)

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/d8144bb9-26b3-4c27-93c9-3018e66da816)

## API

A API tem uma documentação no swagger que pode ser vista ao executar o projeto, na url 'https://localhost:7298/ui/index.html'

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/68c8aca3-c07f-4ac8-80cd-e5470113f19f)

## UI

A UI vai estar na URL 'http://localhost:5211' ou 'https://localhost:7075', ao executar pelo Visual Studio

A interface tem as 3 seguintes telas

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/ca0d2d12-22c5-4675-878a-756a0e200cbf)

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/5d281fee-0840-4d92-94f0-38ac72914fbb)

![image](https://github.com/v-cobof/Class-Organizer/assets/85073588/0587ccdb-fe0a-4e63-a866-b23acb0fe3d2)


