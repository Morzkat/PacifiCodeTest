using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KHahn.ApplicationProcess.February2021.Data.DataAccess;
using KHahn.ApplicationProcess.February2021.Data.ExtensionMethods;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Managers;
using KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.Managers;
using KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.KHanMapper;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.HttpClient;
using KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.HttpClient;

namespace KHahn.ApplicationProcess.February2021.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(config =>
               config.RegisterValidatorsFromAssemblies(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load)));

            //services.AddDbContext<KHahnApplicationProcessContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:KHahnApplicationProcessDatabase"]));

            services.AddDbContext<KHahnApplicationProcessContext>(options => options.UseInMemoryDatabase(databaseName: "HahnApplicationProcess"));

            services.AddHttpClient();
            services.SetupUnitOfWork();
            services.AddScoped<IKHanMapper, KHanMapper>();
            services.AddScoped<IAssetsManager, AssetsManager>();
            services.AddScoped<ICountryHttpClient, CountryHttpClient>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KHahn.ApplicationProcess.February2021.Web", Version = "v1" });
            });

            var client = Configuration.GetSection("ClientHost").Value;

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                   builder => builder
                    .WithOrigins(Configuration.GetSection("ClientHost").Value)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                  );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KHahn.ApplicationProcess.February2021.Web v1"));

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
