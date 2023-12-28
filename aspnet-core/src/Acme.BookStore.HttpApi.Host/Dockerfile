FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Acme.BookStore.HttpApi.Host/Acme.BookStore.HttpApi.Host.csproj", "src/Acme.BookStore.HttpApi.Host/"]
COPY ["src/Acme.BookStore.Application/Acme.BookStore.Application.csproj", "src/Acme.BookStore.Application/"]
COPY ["src/Acme.BookStore.Domain/Acme.BookStore.Domain.csproj", "src/Acme.BookStore.Domain/"]
COPY ["src/Acme.BookStore.Domain.Shared/Acme.BookStore.Domain.Shared.csproj", "src/Acme.BookStore.Domain.Shared/"]
COPY ["src/Acme.BookStore.Application.Contracts/Acme.BookStore.Application.Contracts.csproj", "src/Acme.BookStore.Application.Contracts/"]
COPY ["src/Acme.BookStore.EntityFrameworkCore/Acme.BookStore.EntityFrameworkCore.csproj", "src/Acme.BookStore.EntityFrameworkCore/"]
COPY ["src/Acme.BookStore.HttpApi/Acme.BookStore.HttpApi.csproj", "src/Acme.BookStore.HttpApi/"]
RUN dotnet restore "src/Acme.BookStore.HttpApi.Host/Acme.BookStore.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Acme.BookStore.HttpApi.Host"
RUN dotnet build "Acme.BookStore.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acme.BookStore.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.BookStore.HttpApi.Host.dll"]
