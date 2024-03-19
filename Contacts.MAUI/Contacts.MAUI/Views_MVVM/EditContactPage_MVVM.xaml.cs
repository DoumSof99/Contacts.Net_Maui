namespace Contacts.MAUI.Views_MVVM;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage_MVVM : ContentPage
{
	public EditContactPage_MVVM()
	{
		InitializeComponent();
	}

    public string ContactId {
        set {
            
        }
    }
}