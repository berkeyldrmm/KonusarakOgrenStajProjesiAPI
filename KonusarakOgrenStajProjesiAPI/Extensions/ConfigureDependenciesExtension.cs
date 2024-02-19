using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using KonusarakOgrenStajProjesiAPI.Authentication;

namespace KonusarakOgrenStajProjesiAPI.Extensions
{
    public static class ConfigureDependenciesExtension
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            //Bağımlılıkların kontrolü (IoC konteynırına eklenmesi) bu extension metotta yapılıp, program.cs'in yükünün azaltılması amaçlanmıştır.

            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<ICharacterEpisodeRepository, CharacterEpisodeRepository>();

            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<ICharacterEpisodeService, CharacterEpisodeService>();
            services.AddScoped<IApiService, ApiService>();

            services.AddScoped<ApiKeyAuthorizationFilter>();
            services.AddScoped<IApiKeyValidator, ApiKeyValidator>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }
    }
}
