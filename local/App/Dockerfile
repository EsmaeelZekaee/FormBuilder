FROM mcr.microsoft.com/dotnet/sdk:latest AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers

COPY ./src/Loan/Loan.App/Loan.App.csproj ./src/Loan/Loan.App/
COPY ./src/Loan/Loan.Api/Loan.Api.csproj ./src/Loan/Loan.Api/
COPY ./src/Loan/Loan.Core/Loan.Core.csproj ./src/Loan/Loan.Core/
COPY ./src/Loan/Loan.Data/Loan.Data.csproj ./src/Loan/Loan.Data/
COPY ./src/Loan/Loan.Entities/Loan.Entities.csproj ./src/Loan/Loan.Entities/
COPY ./src/Loan/Loan.Repositories/Loan.Repositories.csproj ./src/Loan/Loan.Repositories/
COPY ./src/Loan/Loan.Services/Loan.Services.csproj ./src/Loan/Loan.Services/
COPY ./src/Loan/Loan.Web/Loan.Web.csproj ./src/Loan/Loan.Web/
COPY ./src/Plugins/CryptoCompare/CryptoCompare.csproj ./src/Plugins/CryptoCompare/

COPY ./Loan.sln ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Loan.Web.dll"]