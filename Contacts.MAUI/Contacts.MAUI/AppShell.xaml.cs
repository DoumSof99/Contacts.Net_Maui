﻿using Contacts.MAUI.Views;
using Contacts.MAUI.Views_MVVM;

namespace Contacts.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(TestPage1), typeof(TestPage1));

            Routing.RegisterRoute(nameof(Contacts_MVVM_Page), typeof(Contacts_MVVM_Page));
            Routing.RegisterRoute(nameof(EditContactPage_MVVM), typeof(EditContactPage_MVVM));
        }
    }
}