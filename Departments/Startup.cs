using Departments.BLL.Providers.Contracts;
using Departments.BLL.Providers.Implementations;
using Departments.DAL.EF.Context.Contracts;
using Departments.DAL.EF.Context.Implementations;
using Departments.DAL.Repositories.Contracts;
using Departments.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Departments
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
            services.AddRouting();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddDbContextPool<DepartmentsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeProvider, EmployeeProvider>();
            services.AddTransient<IDepartmentProvider, DepartmentProvider>();
            services.AddTransient<IDbContext, DepartmentsDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            app.UseMvc();

            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{controller}/{action}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });


            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });

            app.UseRouter(routeBuilder.Build());
        }
    }
}
