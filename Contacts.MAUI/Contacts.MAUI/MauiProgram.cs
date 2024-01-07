using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases.PluginInterfaces;
using Contacts.UseCases.Interfaces;
using Contacts.MAUI.Views;
using Contacts.UseCases;

namespace Contacts.MAUI
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
            builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
            builder.Services.AddSingleton<IViewContactUseCase,  ViewContactUseCase>();
            builder.Services.AddTransient<IEditContactUseCase,  EditContactUseCase>();

            builder.Services.AddSingleton<ContactPage>();
            builder.Services.AddSingleton<EditContactPage>();

            return builder.Build();
        }
    }
}