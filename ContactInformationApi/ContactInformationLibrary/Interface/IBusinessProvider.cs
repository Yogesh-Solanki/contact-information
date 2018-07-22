using ContactInformationLibrary.Entity;
using System.Linq;

namespace ContactInformationLibrary.Interface
{
    public interface IBusinessProvider
    {
        IQueryable<Contact> GetContacts();
        Contact GetContact(int id);
        void UpdateContact(Contact contact);
        void AddContact(Contact contact);
        void DeleteContact(int id);
    }
}
