
using BL.Services;
using BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DAL;

namespace BL
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IAddressBL,AddressBL>();
            services.AddScoped<IContactBL, ContacBL>();
            services.AddScoped<ICountryBL, CountryBL>();
            services.AddScoped<IGroupBL, GroupBL>();
            services.AddScoped<ILanguageBL, LanguageBL>();
            services.AddScoped<ILoginBL, LoginBL>();
            services.AddScoped<IStatusBL, StatusBL>();


        }
    }
}