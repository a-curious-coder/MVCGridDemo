# ===== BUILD STAGE =====
# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["MVCGridProject.csproj", "MVCGridProject/"]
RUN dotnet restore "MVCGridProject/MVCGridProject.csproj"

# Copy everything else and build
COPY . "MVCGridProject/"
WORKDIR /src/MVCGridProject
RUN dotnet build "MVCGridProject.csproj" -c Release -o /app/build

# ===== PUBLISH STAGE =====
FROM build as publish
RUN dotnet publish "MVCGridProject.csproj" -c Release -o /app/publish

# ===== RUN STAGE =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCGridProject.dll"]