using System.Collections.Generic;
using System.Linq;

namespace ContactInformationApi.Mapper
{
    internal class ContactMapper
    {
        internal ContactInformationLibrary.Entity.Contact ModelToDbEntity(Models.Contact contact)
        {
            ContactInformationLibrary.Entity.Contact dbContact = new ContactInformationLibrary.Entity.Contact();
            dbContact.Id = contact.Id;
            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.Email = contact.Email;
            dbContact.PhoneNumber = contact.PhoneNumber;
            dbContact.Status = contact.Status;
            return dbContact;
        }

        internal Models.Contact DbEntityToModel(ContactInformationLibrary.Entity.Contact dbContact)
        {
            Models.Contact contact = new Models.Contact();
            contact.Id = dbContact.Id;
            contact.FirstName = dbContact.FirstName;
            contact.LastName = dbContact.LastName;
            contact.Email = dbContact.Email;
            contact.PhoneNumber = dbContact.PhoneNumber;
            contact.Status = dbContact.Status;
            return contact;
        }

        internal IEnumerable<Models.Contact> DbEntitiesToListModel(IQueryable<ContactInformationLibrary.Entity.Contact> dbContacts)
        {
            return dbContacts.Select(item => new Models.Contact() { Id= item.Id, FirstName = item.FirstName, LastName = item.LastName, Email = item.Email, PhoneNumber = item.PhoneNumber, Status = item.Status }).AsEnumerable();
        }
    }
}