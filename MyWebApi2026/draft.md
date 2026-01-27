dotnet new webapi -n MyWebApi2026

Get
https://localhost:7059/api/hello

dotnet --version
> 9

dotnet run

dotnet build 

dotnet publish -c Release

.gitignore

create controllers 
create services    
create repositories

https://localhost:7059/api/user
https://localhost:7059/api/user/1

Next upgrades (your call 👇)
🔹 Replace in-memory repo with EF Core
🔹 Add Unit Tests (xUnit + Moq)
🔹 Add DTO + AutoMapper
🔹 Apply Clean Architecture (Domain / Application / Infrastructure)


Install EF Core packages
	dotnet add package Microsoft.EntityFrameworkCore
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	dotnet add package Microsoft.EntityFrameworkCore.Tools

	dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
	dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 9.0.0

dotnet list package


InvalidOperationException - when AppDbContext not added to Program.cs AddDbContext
System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: MyWebApi2026.Repositories.Interface.IUserRepository Lifetime: Scoped ImplementationType: MyWebApi2026.Repositories.UserRepository': Unable to resolve service for type 'MyWebApi2026.Data.AppDbContext' while attempting to activate 'MyWebApi2026.Repositories.UserRepository'.) (Error while validating the service descriptor 'ServiceType: MyWebApi2026.Services.Interfaces.IUserService Lifetime: Scoped ImplementationType: MyWebApi2026.Services.UserService': Unable to resolve service for type 'MyWebApi2026.Data.AppDbContext' while attempting to activate 'MyWebApi2026.Repositories.UserRepository'.)'


Add swagger 
	   dotnet add package Swashbuckle.AspNetCore
   
Next steps:
	"Add DTOs"
	"Add validation"
	"Add global exception handling"
	"Add integration tests"
	"Switch DB by environment"
	"Convert to minimal APIs"


# JWT 

  dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.5

# ----- -----  ----- ----- ----- || ----- -----  ----- ----- -----  
  
# Microservice
want to build microservices
api-gateway, user-service, product-service

In microservice architecture, 
In java spring ecosystem; spring cloud is used to build api gateway. 
what technology is used in dotnet core 9 techstack ecostystem?

> In the .NET 9 ecosystem, 
	the primary technology used to build an API Gateway for microservices is YARP (Yet Another Reverse Proxy). 
	Developed by Microsoft, it is a highly customizable, efficient reverse proxy library designed specifically for .NET, 
	often replacing older solutions like Ocelot in modern, high-performance .NET architectures. 
	Primary Choice: YARP (Yet Another Reverse Proxy) is the recommended approach, designed for ASP.NET Core 9.
	Alternative: Ocelot is a popular, mature open-source API Gateway for .NET, though YARP is generally preferred for performance-intensive scenarios.
	Key Features in .NET 9: These gateways support critical, cloud-native features like dynamic routing, authentication, rate limiting, and load balancing, similar to Spring Cloud Gateway.
	Resilience: YARP pairs with Polly in .NET for circuit breaking and retry logic, mimicking Resilience4J in the Java ecosystem. 
	;
	YARP was released on 2021 alongside .NET 6
	;
	dotnet core was introduced in 2016

# ----- -----  ----- ----- ----- || ----- -----  ----- ----- -----  


# -----
# Keyboard shortcuts

Edit.GoToAll
Ctrl + ,

# -----

























