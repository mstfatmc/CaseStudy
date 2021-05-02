
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Dal.Context;
using CaseStudy.Dal.Repositories;
using CaseStudy.Services;
using CaseStudy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Case Study Demo",
                    Description = "Demo API for case study",
                    Version = "v1"

                });
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IJobService, JobService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
        }

        public static void AddCustomContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(o =>
                o.UseSqlite("Data source=casestudy.db",
                    optionsBuilder => optionsBuilder.MigrationsAssembly("CaseStudy")));
        }
    }
}
