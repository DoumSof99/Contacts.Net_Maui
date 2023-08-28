namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}"); // or ".."
    }

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {

    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {

    }

    private void contactCtrl_OnError(object sender, string e)
    {

    }
}