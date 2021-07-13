using System;
namespace Csharp.UsersApi.Configuration
{
    public static class Constants
    {
        public static string MONGO_CONNECTION_STRING = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_CONNECTION_STRING")) ? "mongodb://localhost" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_CONNECTION_STRING");

        public static string MONGO_DATABASE = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_DATABASE")) ? "users" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_DATABASE");

        public static string MONGO_PORT = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_PORT")) ? "27017" : Environment.GetEnvironmentVariable("ASPNETCORE_MONGO_PORT");

        public static string MYSQL_SERVER = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_SERVER")) ? "localhost:3306" : Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_SERVER");

        public static string MYSQL_DATABASE = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_DATABASE")) ? "users" : Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_DATABASE");

        public static string MYSQL_USER = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_USER")) ? "root" : Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_USER");

        public static string MYSQL_PASSWORD = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_PASSWORD")) ? "password" : Environment.GetEnvironmentVariable("ASPNETCORE_MYSQL_PASSWORD");
        public static string ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}