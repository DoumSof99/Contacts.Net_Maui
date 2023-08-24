using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.MAUI.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact() { ContactId = 1, Name = "Sofia", Email="SofDoum@email.com" },
            new Contact() { ContactId = 2, Name = "Irini", Email="Irini@email.com" },
            new Contact() { ContactId = 3, Name = "Maria", Email="Maria@email.com" },
            new Contact() { ContactId = 4, Name = "Menia", Email="Menia@email.com" },
            new Contact() { ContactId = 5, Name = "Agapi", Email="Agapi@email.com" }
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Address = contact.Address,
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                };
            }
            return null;
        }

        public static void UpdeteContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;
            
            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                //AutoMapper
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
            }
        }
    }
}
