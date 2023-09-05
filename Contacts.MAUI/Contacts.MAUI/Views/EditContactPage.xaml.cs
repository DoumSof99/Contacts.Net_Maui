using Contacts.MAUI.Models;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private CoreBusiness.Contact contact;
    private readonly IViewContactUseCase viewContactUseCase;

    public EditContactPage(IViewContactUseCase viewContactUseCase)
	{
		InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
    }

	public string ContactId { 
		set { 
			contact = viewContactUseCase.ExecuteAsync(int.Parse(value)).GetAwaiter().GetResult();
            
            if (contact != null)
			{
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;
            }
        } 
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = contactCtrl.Name;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Address = contactCtrl.Address;


        //ContactRepository.UpdeteContact(contact.ContactId, contact);
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}"); // or ".."
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}