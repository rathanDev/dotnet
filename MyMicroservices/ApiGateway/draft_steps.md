

dotnet new webapi -n ApiGateway
dotnet new webapi -n UserService
dotnet new webapi -n ProductService

dotnet sln add ApiGateway UserService ProductService


dotnet add package Yarp.ReverseProxy
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer


dotnet run --project ApiGateway


dotnet add package Yarp.ReverseProxy

# EntityFramework

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package BCrypt.Net-Next


dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0

dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.18

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0




# EntityFramework Tools
dotnet tool install --global dotnet-ef

		dotnet tool restore
		dotnet ef --version

dotnet-ef tool restore
dotnet-ef migrations add InitialCreate
dotnet-ef database update





dotnet add package Dapper
dotnet add package Microsoft.Data.Sqlite
