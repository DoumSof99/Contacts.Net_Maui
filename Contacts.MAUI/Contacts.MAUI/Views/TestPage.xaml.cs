using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

public partial class TestPage : ContentPage
{
	private Contact _contact;

	public TestPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing() {
        base.OnAppearing();

        _contact = ContactRepository.GetContactById(1);
        this.entryName.Text = _contact.Name;
        this.entryEmail.Text = _contact.Email;
        this.entryPhone.Text = _contact.Phone;
        this.entryAddress.Text = _contact.Address;
    }

    private void btnSave_Clicked(object sender, EventArgs e) {
        _contact.Name = this.entryName.Text;
        _contact.Email = this.entryEmail.Text;
        _contact.Address = this.entryAddress.Text;
        _contact.Phone = this.entryPhone.Text;

        ContactRepository.UpdeteContact(_contact.ContactId, _contact);
    }
}