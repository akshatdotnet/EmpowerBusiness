﻿using Empower.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data
{
    public static class DataServiceModules
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("HangfireConnection");

            services.AddDbContext<EPowerDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
