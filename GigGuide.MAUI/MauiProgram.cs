using CommunityToolkit.Maui;
using GigGuide.MAUI.Services;
using GigGuide.MAUI.Services.Interfaces;
using GigGuide.MAUI.ViewModels;
using GigGuide.MAUI.Views;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
            builder.Services.AddSingleton<ICustomerService, CustomerService>();
            builder.Services.AddSingleton<IConcertService, ConcertService>();
            builder.Services.AddSingleton<IPerformanceService, PerformanceService>();
            builder.Services.AddSingleton<IBookingService, BookingService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Pages
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ConcertListPage>();
            builder.Services.AddTransient<ConcertPerformanceListPage>();
            builder.Services.AddTransient<BookingPage>();
            builder.Services.AddSingleton<CustomerPage>();
            builder.Services.AddTransient<LoginPage>();


            // ViewModels
            builder.Services.AddSingleton<ConcertListViewModel>();
            builder.Services.AddTransient<ConcertPerformanceListViewModel>();
            builder.Services.AddTransient<BookingViewModel>();
            builder.Services.AddSingleton<CustomerViewModel>();
            builder.Services.AddTransient<LoginViewModel>();

            //var loginPage = builder.Services.BuildServiceProvider().GetService<LoginPage>();
            //Debug.Assert(loginPage != null, "LoginPage was not resolved by DI!");



            return builder.Build();
        }
    }
}
