using Microsoft.Extensions.Logging;
using PokemonApp.Services;
using PokemonApp.ViewModels;

namespace PokemonApp
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<GamePage>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<GameViewModel>();

            builder.Services.AddSingleton<PokemonService>();
            builder.Services.AddSingleton<GameService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
