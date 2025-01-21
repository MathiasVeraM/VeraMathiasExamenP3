using Microsoft.Extensions.Logging;
using VeraMathiasExamenP3.Interfaces;
using VeraMathiasExamenP3.Repositories;

namespace VeraMathiasExamenP3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IMVeraPeliculaAPI, MVeraPeliculaAPIRepository>();
            builder.Services.AddTransient<MainPage> ();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
