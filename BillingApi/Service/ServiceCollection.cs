using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Service.CharacterServiceObj;
using BillingApi.Service.AppServiceObj;
using BillingApi.Service.BaseCurrencyServiceObj;

namespace BillingApi.Service
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IBaseCurrencyService, BaseCurrencyService>();
            return services;
        }
    }
}
