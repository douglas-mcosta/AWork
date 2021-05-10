#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/AWork.Candidate.API/AWork.Candidate.API.csproj", "src/AWork.Candidate.API/"]
COPY ["src/AWork.Application/AWork.Application.csproj", "src/AWork.Application/"]
COPY ["src/AWork.Business/AWork.Business.csproj", "src/AWork.Business/"]
COPY ["src/AWork.Data/AWork.Data.csproj", "src/AWork.Data/"]
RUN dotnet restore "src/AWork.Candidate.API/AWork.Candidate.API.csproj"
COPY . .
WORKDIR "/src/src/AWork.Candidate.API"
RUN dotnet build "AWork.Candidate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AWork.Candidate.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWork.Candidate.API.dll"]