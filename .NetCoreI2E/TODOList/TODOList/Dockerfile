FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TODOList/TODOList.csproj", "TODOList/"]
RUN dotnet restore "TODOList/TODOList.csproj"
COPY . .
WORKDIR "/src/TODOList"
RUN dotnet build "TODOList.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TODOList.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TODOList.dll"]