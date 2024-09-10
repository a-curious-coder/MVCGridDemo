# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["MVCGridProject.csproj", "./"]
RUN dotnet restore "MVCGridProject.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "MVCGridProject.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "MVCGridProject.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5001
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Expose port 5001
EXPOSE 5001

# Set the entry point
ENTRYPOINT ["dotnet", "MVCGridProject.dll"]