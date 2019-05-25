FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Applications/StudentApp.Web/StudentApp.Web.csproj", "Applications/StudentApp.Web/"]
RUN dotnet restore "Applications/StudentApp.Web/StudentApp.Web.csproj"
COPY . .
WORKDIR "/src/Applications/StudentApp.Web"
RUN dotnet build "StudentApp.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StudentApp.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentApp.Web.dll"]