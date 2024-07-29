using Song.Api.Services;
using Song.Api.Settings;

namespace Song.Api.Common
{
    public static class BuildExtension
    {
        public static void AddSwaggerDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<SongDatabaseSettings>(
                builder.Configuration.GetSection(nameof(SongDatabaseSettings)));
        }
        public static void ConfigureDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ISongService, SongService>();
        }
    }
}
