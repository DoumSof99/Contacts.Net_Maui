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
            new Contact() { Name = "Sofia", Email="SofDoum@email.com" },
            new Contact() { Name = "Irini", Email="Irini@email.com" },
            new Contact() { Name = "Maria", Email="Maria@email.com" },
            new Contact() { Name = "Menia", Email="Menia@email.com" },
            new Contact() { Name = "Agapi", Email="Agapi@email.com" }
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }

    }
}
