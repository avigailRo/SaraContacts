
using DAL.Interfaces;
using DAL.Implementation;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;


namespace DAL
{
    public static class RepositoryCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();


        }
    }
}