FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copie o código-fonte para o container
COPY . ./SongApi

# Restaure as dependências e publique o build
RUN dotnet restore SongApi/Song.Api.csproj
RUN dotnet publish SongApi/Song.Api.csproj -c Release -o /app

# Use a imagem final do ASP.NET Core para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copie os arquivos compilados do estágio de build
COPY --from=build /app .

ENTRYPOINT ["dotnet", "Song.Api.dll"]
CMD [ "host=0.0.0.0" ]