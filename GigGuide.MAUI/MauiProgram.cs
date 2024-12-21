using CommunityToolkit.Maui;
using GigGuide.MAUI.Services;
using GigGuide.MAUI.Services.Interfaces;
using GigGuide.MAUI.ViewModels;
using GigGuide.MAUI.Views;
using Microsoft.Extensions.Logging;

namespace GigGuide.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            builder.Services.AddSingleton<IRestService, RestService>();
            builder.Services.AddSingleton<IConcertService, ConcertService>();
            builder.Services.AddSingleton<IPerformanceService, PerformanceService>();
            builder.Services.AddSingleton<IBookingService, BookingService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Pages
            builder.Services.AddSingleton<ConcertListPage>();
            builder.Services.AddTransient<ConcertPerformanceListPage>();
            builder.Services.AddTransient<BookingPage>();

            // ViewModels
            builder.Services.AddSingleton<ConcertListViewModel>();
            builder.Services.AddTransient<ConcertPerformanceListViewModel>();
            builder.Services.AddTransient<BookingViewModel>();

            return builder.Build();
        }
    }
}
