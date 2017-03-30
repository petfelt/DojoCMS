using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;

//https://www.benday.com/2017/02/17/ef-core-migrations-without-hard-coding-a-connection-string-using-idbcontextfactory/

namespace DojoCMS
{
    public class BloggingContextFactory : IDbContextFactory<BloggingContext>
    {      
        private string DbName;

        public BloggingContextFactory(string dbName)
        {
            DbName =  dbName;
        }
        
        public BloggingContext Create()
        {
            var environmentName =
                        Environment.GetEnvironmentVariable(
                            "Hosting:Environment");

            var basePath = AppContext.BaseDirectory;

            return Create(basePath, environmentName);
        }

        public BloggingContext Create(DbContextFactoryOptions options)
        {
            
            return Create(
                options.ContentRootPath,
                options.EnvironmentName);
        }

        private BloggingContext Create(string basePath, string environmentName)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            IConfiguration Configuration  = builder.Build();

            

            var connstr = Configuration["DBInfo:ConnectionString"];

            connstr = connstr.Replace("database=mydb", $"database={DbName}");
            

            if (String.IsNullOrWhiteSpace(connstr) == true)
            {
                throw new InvalidOperationException(
                    $"Could not find a connection string named '({DbName})'.");
            }
            else
            {
                return Create(connstr);
            }
        }

        private BloggingContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var optionsBuilder =
                new DbContextOptionsBuilder<BloggingContext>();

            optionsBuilder.UseMySQL(connectionString);

            return new BloggingContext(optionsBuilder.Options);
        }
    }
}