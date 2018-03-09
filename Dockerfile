FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./

COPY Assessmentsvc/Assessmentsvc.csproj Assessmentsvc/
COPY Assessmentsvc.Database/Assessmentsvc.Database.csproj Assessmentsvc.Database/
COPY Assessmentsvc.Database.Entity/Assessmentsvc.Database.Entity.csproj Assessmentsvc.Database.Entity/
COPY ExcelHelper/ExcelHelper.csproj ExcelHelper/

RUN dotnet restore
COPY . ./
WORKDIR /src/Assessmentsvc
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app
COPY Assessmentsvc/Drrsnlite.xlsx /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Assessmentsvc.dll"]
