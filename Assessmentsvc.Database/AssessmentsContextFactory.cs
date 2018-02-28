using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Assessmentsvc.Database
{
    public class AssessmentsContextFactory : IDesignTimeDbContextFactory<AssessmentsContext>
    {
        public AssessmentsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();


            var builder = new DbContextOptionsBuilder<AssessmentsContext>().EnableSensitiveDataLogging(true);

            string dbname = configuration["MYSQL_DATABASE"];
            string dbuser = configuration["MYSQL_USER"];
            string dbpwd = configuration["MYSQL_PASSWORD"];
            string dbserver = configuration["MYSQL_SERVICE_HOST"];
            string dbport = configuration["MYSQL_SERVICE_PORT"];
            var mySQLconnectionString = "Server=" + configuration["MYSQL_SERVICE_HOST"] + "; Port = " + configuration["MYSQL_SERVICE_PORT"] + "; Database = " + configuration["MYSQL_DATABASE"] + "; Uid= " + configuration["MYSQL_USER"] + ";Pwd=" + configuration["MYSQL_PASSWORD"] + ";";

            builder.UseSqlServer(mySQLconnectionString);

            return new AssessmentsContext(builder.Options);
        }
    }
}
