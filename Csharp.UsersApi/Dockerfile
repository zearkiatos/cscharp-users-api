FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY *.sln .
COPY Csharp.UsersApi/*.csproj ./Csharp.UsersApi/
COPY Csharp.UsersApi/. ./Csharp.UsersApi/
COPY Csharp.UsersApi.Tests/*.csproj ./Csharp.UsersApi.Tests/
COPY Csharp.UsersApi.Tests/. ./Csharp.UsersApi.Tests/
RUN dotnet sln remove ./Csharp.UsersApi.Tests/*.csproj
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Csharp.UsersApi.dll",  "--urls", "http://*:80"]