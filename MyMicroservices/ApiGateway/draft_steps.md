

dotnet new webapi -n ApiGateway
dotnet new webapi -n UserService
dotnet new webapi -n ProductService

dotnet sln add ApiGateway UserService ProductService


dotnet add package Yarp.ReverseProxy
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer


dotnet run --project ApiGateway


dotnet add package Yarp.ReverseProxy