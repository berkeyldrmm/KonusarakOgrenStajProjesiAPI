using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace KonusarakOgrenStajProjesiAPI.Extensions
{
    public static class ConfigureDependenciesExtension
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            //Bağımlılıkların kontrolü (IoC konteynırına eklenmesi) bu extension metotta yapılıp, program.cs'in yükünün azaltılması amaçlanmıştır.

            services.AddScoped<ICharacterRepository,CharacterRepository>();
            services.AddScoped<IEpisodeRepository,EpisodeRepository>();

            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
        }
    }
}
