using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Assessmentsvc.Database;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Cors;

namespace Api
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }
        public bool UseInMemoryDatabase;


        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            HostingEnvironment = env;
            Configuration = config;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            UseInMemoryDatabase = Configuration["USE_IN_MEMORY_DATABASE"] == "true" ? true:false;

            if (UseInMemoryDatabase)
            {
                services.AddDbContext<AssessmentsContext>(opt => opt.UseInMemoryDatabase("Assessmentsvc.Database"));
            }
            else
            {
                string dbname = Configuration["MYSQL_DATABASE"];
                string dbuser = Configuration["MYSQL_USER"];
                string dbpwd = Configuration["MYSQL_PASSWORD"];
                string dbserver = Configuration["MYSQL_SERVICE_HOST"];
                string dbport = Configuration["MYSQL_SERVICE_PORT"];
                var connection = "Server=" + Configuration["MYSQL_SERVICE_HOST"]+"; Port = "+Configuration["MYSQL_SERVICE_PORT"]+"; Database = "+Configuration["MYSQL_DATABASE"]+"; Uid= "+ Configuration["MYSQL_USER"]+";Pwd="+ Configuration["MYSQL_PASSWORD"]+";";

                services.AddDbContext<AssessmentsContext>(opt => opt.UseMySql(connection, b => b.MigrationsAssembly("Assessmentsvc.Database")));
            }
            string cors_origin = Configuration["CORS_ORIGIN"];
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins(cors_origin).AllowAnyHeader());
            });
            services.AddMvc();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Assessments Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    if (!UseInMemoryDatabase && !serviceScope.ServiceProvider.GetService<AssessmentsContext>().AllMigrationsApplied())
                    {
                        serviceScope.ServiceProvider.GetService<AssessmentsContext>().Database.Migrate();
                    }
                         serviceScope.ServiceProvider.GetService<AssessmentsContext>().EnsureSeeded();
               }
                  
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assessments Service V1");
            });
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }
    }
}
