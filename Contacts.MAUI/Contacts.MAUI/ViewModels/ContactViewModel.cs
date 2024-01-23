using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.ViewModels {
    public partial class ContactViewModel : ObservableObject {

        public Contact Contact { get; set; }

        public ContactViewModel()
        {
            this.Contact = ContactRepository.GetContactById(1);
        }

        [RelayCommand]
        public void SaveContact() {
            ContactRepository.UpdeteContact(this.Contact.ContactId, this.Contact);
        }
    }
}
