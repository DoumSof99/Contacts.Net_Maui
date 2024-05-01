using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

using Contacts.Plugins.DataStore.InMemory;
using Contacts.Plugins.DataStore.SQLLite;
using Contacts.UseCases.PluginInterfaces;
using Contacts.UseCases.Interfaces;
using Contacts.MAUI.Views;
using Contacts.UseCases;
using Contacts.MAUI.ViewModels;
using Contacts.MAUI.Views_MVVM;
using Contacts.Plugins.DataStore.WebApi;

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
            //builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            //builder.Services.AddSingleton<IContactRepository, ContactSQLiteRepository>();
            builder.Services.AddSingleton<IContactRepository, ContactWebApiRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
            builder.Services.AddSingleton<IViewContactUseCase,  ViewContactUseCase>();
            builder.Services.AddTransient<IEditContactUseCase,  EditContactUseCase>();
            builder.Services.AddTransient<IAddContactUseCase,  AddContactUseCase>();
            builder.Services.AddTransient<IDeleteContactUseCase,  DeleteContactUseCase>();

            builder.Services.AddSingleton<ContactsViewModel>();
            builder.Services.AddSingleton<ContactViewModel>();

            builder.Services.AddSingleton<ContactPage>();
            builder.Services.AddSingleton<EditContactPage>();
            builder.Services.AddSingleton<AddContactPage>();

            builder.Services.AddSingleton<Contacts_MVVM_Page>();
            builder.Services.AddSingleton<EditContactPage_MVVM>();
            builder.Services.AddSingleton<AddContactPage_MVVM>();

            return builder.Build();
        }
    }
}