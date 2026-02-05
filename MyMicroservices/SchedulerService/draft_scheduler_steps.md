
# -----

dotnet new webapi -n SchedulerService
cd SchedulerService 

dotnet add package Hangfire 

dotnet add package Microsoft.Data.SqlClient

# Docker 
cd DockerStuff/
docker ps 
docker compose up -d 

docker compose down -v 

docker logs mssql

docker volume ls 
docker compose down -v 
docker system prune -f 





# Use MsSQL as the storage for Hangfire
dotnet add package Hangfire.SqlServer 

dotnet add package Serilog.AspNetCore

dotnet sln add SchedulerService/SchedulerService.csproj

# -----

Use **FULL recovery model** and **READ_COMMITTED_SNAPSHOT ON**.

```sql
ALTER DATABASE HangfireDb
SET READ_COMMITTED_SNAPSHOT ON;
```


# -----
