using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases
{
    // All the code in this file is included in all platforms.
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContactRepository contactRepositiry;
        public ViewContactsUseCase(IContactRepository contactRepositiry)
        {
            this.contactRepositiry = contactRepositiry;
        }

        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await this.contactRepositiry.GetContactsAsync(filterText);
        }
    }
}