# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy only the solution file and restore dependencies
COPY ./TorrentTracker/TorrentTracker.csproj .
RUN dotnet restore 

# Copy the entire solution to leverage Docker cache for dependencies
COPY ./ProtocolParser/ProtocolParser.csproj .



# Build and publish the TorrentTracker project

COPY . .
WORKDIR /App/TorrentTracker
RUN dotnet publish -c Release -o out


WORKDIR /App/TorrentTracker/out
RUN mkdir TorrentFile
RUN touch Dictionary.json

# Build the runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App/TorrentTracker
COPY --from=build-env /App/TorrentTracker/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "TorrentTracker.dll"]