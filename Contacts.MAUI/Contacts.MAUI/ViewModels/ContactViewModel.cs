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
        private Contact contact;
        public Contact Contact {
            get => contact;
            set {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel()
        {
            this.Contact = new Contact();
        }

        public void LoadContact(int contactId) {
            this.Contact = ContactRepository.GetContactById(contactId);
        }

        [RelayCommand]
        public void SaveContact() {
            ContactRepository.UpdeteContact(this.Contact.ContactId, this.Contact);
        }
    }
}
