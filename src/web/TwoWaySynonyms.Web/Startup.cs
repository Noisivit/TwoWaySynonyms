using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwoWaySynonyms.Application.Services;
using TwoWaySynonyms.ApplicationContracts.Services;
using TwoWaySynonyms.Infrastructure.Database;
using TwoWaySynonyms.Infrastructure.Repositories.TermRepository;
using TwoWaySynonyms.Infrastructure.Services;
using TwoWaySynonyms.InfrastructureContracts.Repositories;
using TwoWaySynonyms.InfrastructureContracts.Services;

namespace TwoWaySynonyms.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDbContext<TwoWaySynonymsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TwoWaySynonymsConnection")));

            services.AddScoped<ISynonymService, SynonymService>();
            services.AddScoped<ISynonymStructureService, SynonymStructureService>();
            services.AddScoped<ITermRepository, TermRepository>();

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
