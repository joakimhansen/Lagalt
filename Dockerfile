# DOCKERFILE

## Build app
# 1 - Base image to work from SDK for .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage

# 2 - Set working directory
WORKDIR /app

# 3 - Copy source files to image
COPY . ./

# 4 - Install missing dependencies
RUN dotnet restore

# 5 - Publish application to image
RUN dotnet publish -c Release -o out



## Run app
# 1 - Image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# 2 - Re-establish working directory
WORKDIR /app

# 3 - Copy published files from build stage
COPY --from=build-stage /app/out .

# 4 - How the application is run
ENTRYPOINT ["dotnet", "Lagalt_backend.dll"]