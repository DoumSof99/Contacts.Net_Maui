﻿using Contacts.UseCases.PluginInterfaces;
using SQLite;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.SQLLite {
    // All the code in this file is included in all platforms.
    public class ContactSQLiteRepository : IContactRepository {

        private SQLiteAsyncConnection database;
        public ContactSQLiteRepository()
        {
            this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
            this.database.CreateTableAsync<Contact>();
        }

        public async Task AddContactAsync(Contact contact) {
            await this.database.InsertAsync(contact);
        }

        public async Task DeleteContactAsync(int contactId) {
            var contact = await GetContactByIdAsync(contactId);
            if (contact != null && contact.ContactId == contactId) {
                await this.database.DeleteAsync(contact);
            }
        }

        public async Task<Contact> GetContactByIdAsync(int contactId) {
            return await this.database.Table<Contact>().Where(x => x.ContactId == contactId).FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetContactsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                return await this.database.Table<Contact>().ToListAsync();
            }

            return await this.database.QueryAsync<Contact>(
                @"SELECT * FROM Contacts 
                WHERE Name LIKE ? 
                OR Email LIKE ? 
                OR Phone LIKE ? 
                OR Address LIKE ?",
                $"{filterText}%", $"{filterText}%", $"{filterText}%", $"{filterText}%");
        }

        public async Task UpdateContactAsync(int contactId, Contact contact) {
            if (contactId == contact.ContactId) {
                await this.database.UpdateAsync(contact);
            }
        }
    }
}
