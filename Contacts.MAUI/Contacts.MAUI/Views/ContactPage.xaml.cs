namespace Contacts.MAUI.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>() 
		{ 
			new Contact() { Name = "Sofia", Email="SofDoum@email.com" },
            new Contact() { Name = "Irini", Email="Irini@email.com" },
            new Contact() { Name = "Maria", Email="Maria@email.com" },
            new Contact() { Name = "Menia", Email="Menia@email.com" },
            new Contact() { Name = "Agapi", Email="Agapi@email.com" }
        };
		
        listContacts.ItemsSource = contacts;

    }

	public class Contact
	{
        public string Name { get; set; }
        public string Email { get; set; }


    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync(nameof(EditContactPage));
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;   
    }
}