#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GitAssessment.Api/GitAssessment.Api.csproj", "GitAssessment.Api/"]
RUN dotnet restore "GitAssessment.Api/GitAssessment.Api.csproj"
COPY . .
WORKDIR "/src/GitAssessment.Api"
RUN dotnet build "GitAssessment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitAssessment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitAssessment.Api.dll"]