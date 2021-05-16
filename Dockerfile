FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY MvcEmptyTemplate.sln ./
COPY MvcEmptyTemplate.Domain/MvcEmptyTemplate.Domain.csproj MvcEmptyTemplate.Domain/
COPY MvcEmptyTemplate.Infrastructure/MvcEmptyTemplate.Infrastructure.csproj MvcEmptyTemplate.Infrastructure/
COPY MvcEmptyTemplate.WebApp/MvcEmptyTemplate.WebApp.csproj MvcEmptyTemplate.WebApp/
RUN dotnet restore

# copy everything else and build app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
EXPOSE 5001
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "MvcEmptyTemplate.WebApp.dll"]

