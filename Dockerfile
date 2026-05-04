# Usa SDK direto (igual dotnet run)
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview

WORKDIR /app

# Copia tudo
COPY . ./

# Restaura
RUN dotnet restore

# Expõe porta
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# Roda exatamente como você roda local
CMD ["dotnet", "run", "--urls=http://0.0.0.0:8080"]