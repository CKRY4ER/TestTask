using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TestTask.Application.Interface;
using Microsoft.EntityFrameworkCore;


namespace TestTask.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TestTaskDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITestTaskDbContext>(provider => provider.GetService<TestTaskDbContext>());
            return services;
        }
    }
}
