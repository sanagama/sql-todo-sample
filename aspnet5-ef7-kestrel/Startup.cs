using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using TodoApp.Models;
using Newtonsoft.Json.Serialization;

namespace TodoApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entitry Framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TodoAppContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:TodoAppDB"]));

            // Add MVC
            services.AddMvc().AddJsonOptions(options =>
            {
                // handle loops correctly
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                // use standard name conversion of properties
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });            
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // For demo purposes, we will drop and recreate the database at each run
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                TodoAppContext ctx = serviceScope.ServiceProvider.GetService<TodoAppContext>(); 
                
                // Drop & recreate the DB at each run (we're not using EF DB migrations)
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                // Put some sample data into the database per EF7 guidance here: https://github.com/aspnet/EntityFramework/issues/3042
                ctx.EnsureSeedData();
            }
                
            app.UseIISPlatformHandler();

            app.UseStaticFiles();
                        
            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}