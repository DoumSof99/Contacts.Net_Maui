using Contacts.MAUI.Models;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
    private IAddContactUseCase addContactUseCase;
	public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        this.addContactUseCase = addContactUseCase;
	}

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        
        await addContactUseCase.ExecuteAsync(new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Address = contactCtrl.Address,
            Phone = contactCtrl.Phone
        });

        await Shell.Current.GoToAsync($"//{nameof(ContactPage)}"); // or ".."
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}"); // or ".."
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}