FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Restores the dependencies and tools of the project.
COPY . ./
RUN dotnet restore ./GmailEmailProblem.API
RUN dotnet publish ./GmailEmailProblem.API -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
# copy over the source for development build
COPY --from=build-env /app ./source
# copy build output for actual runtime
COPY --from=build-env /app/GmailEmailProblem.API/out .
CMD ["dotnet", "GmailEmailProblem.API.dll"]