using System;
using System.IO;
using Assessmentsvc.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<AssessmentsContext>
    {
        public AssessmentsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
            
            var builder = new DbContextOptionsBuilder<AssessmentsContext>().EnableSensitiveDataLogging(true);
            if (Configuration["USE_IN_MEMORY_DATABASE"] == "true")
            {

                builder.UseInMemoryDatabase("Assessmentsvc.Database");

            }
            else
            {
                string dbname = Configuration["MYSQL_DATABASE"];
                string dbuser = Configuration["MYSQL_USER"];
                string dbpwd = Configuration["MYSQL_PASSWORD"];
                string dbserver = Configuration["MYSQL_SERVICE_HOST"];
                string dbport = Configuration["MYSQL_SERVICE_PORT"];
                var mySQLconnectionString = "Server=" + Configuration["MYSQL_SERVICE_HOST"] + "; Port = " + Configuration["MYSQL_SERVICE_PORT"] + "; Database = " + Configuration["MYSQL_DATABASE"] + "; Uid= " + Configuration["MYSQL_USER"] + ";Pwd=" + Configuration["MYSQL_PASSWORD"] + ";";
                builder.UseMySql(mySQLconnectionString, mySqlOptionsAction: sqlOptions =>
                {

                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,

                    maxRetryDelay: TimeSpan.FromSeconds(30),

                    errorNumbersToAdd: null);

                });
            }
                return new AssessmentsContext(builder.Options);
        }
    }
}


