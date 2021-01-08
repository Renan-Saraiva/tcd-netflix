FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5101
EXPOSE 5100
ENV ASPNETCORE_URLS=http://*:5100

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Netflix.Api.Movies/Netflix.Api.Movies.csproj", "Netflix.Api.Movies/"]
COPY ["Netflix.Infrastructure.Abstractions/Netflix.Infrastructure.Abstractions.csproj", "Netflix.Infrastructure.Abstractions/"]
COPY ["Netflix.Infrastructure.IoC/Netflix.Infrastructure.IoC.csproj", "Netflix.Infrastructure.IoC/"]
COPY ["Netflix.Infrastructure.DB/Netflix.Infrastructure.DB.csproj", "Netflix.Infrastructure.DB/"]

RUN dotnet restore "Netflix.Api.Movies/Netflix.Api.Movies.csproj"
COPY . .
WORKDIR "/src/Netflix.Api.Movies/."
RUN dotnet build "Netflix.Api.Movies.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Netflix.Api.Movies.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Netflix.Api.Movies.dll", "--environment=Production"]
