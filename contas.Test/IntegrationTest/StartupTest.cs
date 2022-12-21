using contas_api_model;
using contas_api_model.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Reflection;
using contas_api_model.Repository;

namespace contas_api_test.IntegrationTest
{
    public class StartupTest
    {
        public StartupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("mysqlTestConnection");

            services.RemoveAll<DbContextOptions<Contexto>>();

            services.AddDbContext<Contexto>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            //services.AddDbContext<Contexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Adiciona os controllers do outro projeto
            //Caso fosse um unico projeto contendo a api e os testes, poderia usar apenas o services.AddControllers();
            services.AddControllers().AddApplicationPart(Assembly.Load("contas-api")).AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
