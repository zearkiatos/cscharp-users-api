using System;
namespace Csharp.UsersApi.Configuration
{
    public static class Constants
    {
        public static string MONGO_CONNECTION_STRING = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_CONNECTION_STRING")) ? "mongodb://localhost" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_CONNECTION_STRING");

        public static string MONGO_DATABASE = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_DATABASE")) ? "users" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_DATABASE");

        public static string MONGO_PORT = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_PORT")) ? "27017" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_PORT");
        public static string ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}