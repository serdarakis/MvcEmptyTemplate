FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY StateManagementChallange.sln ./
COPY StateManagementChallange.Domain/StateManagementChallange.Domain.csproj StateManagementChallange.Domain/
COPY StateManagementChallange.Infrastructure/StateManagementChallange.Infrastructure.csproj StateManagementChallange.Infrastructure/
COPY StateManagementChallange.WebApp/StateManagementChallange.WebApp.csproj StateManagementChallange.WebApp/
RUN dotnet restore

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
EXPOSE 5001
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "StateManagementChallange.WebApp.dll"]

