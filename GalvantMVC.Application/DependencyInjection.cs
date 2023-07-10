using GalvantMVC.Application.Interfaces;
using GalvantMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddTransient<IEquipmentService, EquipmentService>();
            return services;
        }
    }
}
