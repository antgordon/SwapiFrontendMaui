﻿using MauiApp1.Services;

namespace MauiApp1;

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
            })
            .Services.AddDependencies();

        return builder.Build();
    }


    private static void AddDependencies(this IServiceCollection services) 
    {
        services.AddSingleton<ISwapiApiService, SwapiApiService>();
    }
}
