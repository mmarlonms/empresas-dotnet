
#Projeto Ioasys

# Api  Empresas

**Objetivo:**
------------


-   Criação de uma API em .NET que atendam aos requisitos do escopo do projeto, listados abaixo.

**Requisitos**  :
-   Deve ser criada uma API em .NET, ou .NET Core.
-   A API deve fazer o seguinte:
-   Login e verificação de acesso de usuários registrados
    -   Para o login usamos padrões OAuth 2.0.
-   Listagem de Empresas
-   Detalhamento de Empresas
-   Filtro de Empresas por nome e tipo


**Solução:**
------------

Para resolver o problema proposto foi utilizado a plataforma .net core por se tratar de um tecnologia em constante evolução e expertise do desenvolver ( no caso eu ) na liguagem. 

Para a parte de Autenticação tive alguns problemas pra realizar a autenticação Oath2 na api, todas as referências que achei apontavam para autenticação na qual se autentica em outro sistema. Para não criar uma arquitetura mais complicada que o necessário optei por criar uma autenticação Oath2 do tipo Password no swagger e autenticar a api em  com Bearer token.  Dessa forma consegui simplificar o login através do Authorize do Swagger e gerar um token as informações de acesso da api Ioasys além das informações do Investidor logado. 

A Solução foi desenvolvida seguindo as boas práticas de desenvolvimento  DDD e SOLID. 
Como Arquitetura de software foi adotado o padrão **Hexagonal** por possibilitar melhor coesão e menor acoplamento entre as camadas, facilitando evoluções futuras. Para referências de projetos com arquiteturas exagonais ficam os seguintes links: 

- [Furiza](https://github.com/ivanborges/furiza-aspnetcore "Furiza")

- [Manga Clean Architecture](https://github.com/ivanpaulovich/clean-architecture-manga "Manga Clean Architecture")

- [Opala](https://github.com/OleConsignado/opala "Opala")

Foram utilizadas outras fontes para implementar a solução: 

[# Utilizando Log em ASP .NET Core]([https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5](https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5))

[ # ASP.NET Core + JWT + Refit: consumindo uma API protegida de forma descomplicada]([https://medium.com/@renato.groffe/asp-net-core-jwt-refit-consumindo-uma-api-protegida-de-forma-descomplicada-9ef4ddfc78ac](https://medium.com/@renato.groffe/asp-net-core-jwt-refit-consumindo-uma-api-protegida-de-forma-descomplicada-9ef4ddfc78ac))

[#Refit]([https://github.com/reactiveui/refit](https://github.com/reactiveui/refit))

[# ASP.NET Core File Logging in one line of code](https://nblumhardt.com/2016/10/aspnet-core-file-logger/)

[# File Logging And MS SQL Logging Using Serilog With ASP.NET Core 2.0](https://www.c-sharpcorner.com/article/file-logging-and-ms-sql-logging-using-serilog-with-asp-net-core-2-0/)

[# A Cleaner Way to Create Mocks in .NET](https://medium.com/webcom-engineering-and-product/a-cleaner-way-to-create-mocks-in-net-6e039c3d1db0)

[# Advanced Architecture for ASP.NET Core Web API](https://www.infoq.com/articles/advanced-architecture-aspnet-core)

**Estrutura do projeto:**

O projeto segue com as seguintes camadas: 

 **Service**
 
	Empresas.Service

**Dominio**   

	Empresas.Domain
**Infra**  

	Empresas.CrossCutting
	Empresas.IoasysApiAdapter
**Api**

	Empresas.WebApi
	
**Testes**

	Empresas.Tests

Onde temos, a camada **Service** Como a camada da regra de negócio da aplicação, nela está contida toda a regra envolvida da aplicação, entretanto por se tratar de um projeto de escopo reduzido as regras de negocio existentes da aplicação atualmente se encontram no projeto de Adapter. 

A camada **Dominio** é a responsável pelo meu domínio, nela temos os contratos das interfaces, os objetos de domínio e as excessões que meu negócio pode gerar.

A Camada **Infra** é responsável pela infra estrutura do projeto. Nela está contida a parte de CrossCutting e Adapter. A parte de  CrossCutting adiciona na aplicação extensões de serviços como a autenticação da aplicação, na camada de Adapter temos a conexão entre a Aplicação  e  API http://empresas.ioasys.com.br/, agindo como um adaptador. 

A camada **Api* é responsável pela camada de apresentação nela colocamos todas as interfaces humanas, APIs ( Swagger ), Sites, Sistemas entre outras coisas. 

E por último mas não menos importante a camada **Testes**, no qual são escritos testes automatizados para validar se o adapter (ponto focal da aplicação) possui falhas.

**Requisitos para execução do projeto:**

O projeto foi desenvolvido na plataforma .net core 2.1 ou seja, é necessário este SDK para executa-lo ;).

Para executar os métodos da controller  **Empresas**  é necessário se autenticar com as credenciais da api [http://empresas.ioasys.com.br/](http://empresas.ioasys.com.br/).:
-   Usuário de Teste: testeapple@ioasys.com.br
-   Senha de Teste :  12341234

Segue exemplo: 

![enter image description here](https://bitbucket.org/mmarlonms/empresas-dotnet/raw/42629f7d800218be0993a7cab6300ed60f3ff570/docs/1.PNG)

![enter image description here](https://bitbucket.org/mmarlonms/empresas-dotnet/raw/42629f7d800218be0993a7cab6300ed60f3ff570/docs/2.PNG)

* não é necessario iformar client_id e client_secret ( Infelizmente não consegui remover esses parâmetros da tela).

Caso esteja utilizando via postman ou por outra chamada é necessário utlizar o método Auth/Token , informando o usuário e senha da [http://empresas.ioasys.com.br/](http://empresas.ioasys.com.br/)

![enter image description here](https://bitbucket.org/mmarlonms/empresas-dotnet/raw/15cad15a5999061a97131b3d8b6e5faa780689a2/docs/3.PNG)

**Plus++**
------------
Como pratica, tenho por  criar pequenos pacotes para auxiliar nas arquiteturas nas quais desenvolvo. Neste projeto pude aplicar as seguintes bibliotecas que estou desenvolvendo:

*  MonteOlimpo.Exception" Version="1.0.0" 
* MonteOlimpo.CoreException" Version="1.0.0" 
* MonteOlimpo.Extensions" Version="1.0.1"
* MonteOlimpo.Filters" Version="1.0.0" 
* MonteOlimpo.Log" Version="1.0.1"

Todas OpenSources disponíveis no meu [GitHub](https://github.com/mmarlonms/MonteOlimpo)

Elas ainda estão em **desenvolvimento** e ainda há muito que se fazer ( como por exemplo melhorar a documentação).

Este projeto meu deu a oportunidade de colocas em prática, então, muito obrigado ;) .


**Conclusão**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos com Injeção de Dependência, arquitetura exagonal e principalmente utilização de testes mocados na aplicação, além de outros conceitos. 

**Melhorias**

Me proponho melhorar o pacote de Swagger que tenho em meu git hub para abrager autenticações via Oath2.

**Observações**
------------
Pelo que foi proposto escopo não a necessidade da utilização de banco dedados. Caso tenham interesse no meu git hub possuem projetos no qual utilizo EF Core para conectar no banco, entre eles estão o [MonteOlimpo](https://github.com/mmarlonms/MonteOlimpo) que utiliza Postgrees. Tenho bastante experiência com SqlServer mas por questões de custo tenho optado por trabalhar com Postgrees. 
