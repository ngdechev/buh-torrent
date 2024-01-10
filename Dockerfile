# Use the .NET 6.0 SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app

# Copy the necessary files
COPY . .
RUN dotnet restore "./TorrentTracker/TorrentTracker.csproj" --disable-parallel
RUN dotnet publish "./TorrentTracker/TorrentTracker.csproj" -c release -o /app/out --no-restore

# Build the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
COPY "./TorrentTracker/bin/Debug/net6.0-windows/TorrentFile" ./app/out
COPY "./TorrentTracker/bin/Debug/net6.0-windows/Dictionary.json" ./app/out

# Expose ports 12345 and 12346
EXPOSE 12345
EXPOSE 12346

# Set the entry point for your application
ENTRYPOINT ["dotnet", "TorrentTracker.dll"]