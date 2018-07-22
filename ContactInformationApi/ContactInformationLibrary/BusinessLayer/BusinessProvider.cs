using ContactInformationLibrary.DatabaseLayer;
using ContactInformationLibrary.Entity;
using ContactInformationLibrary.Interface;
using System;
using System.Linq;

namespace ContactInformationLibrary.BusinessLayer
{
    public class BusinessProvider : IBusinessProvider
    {
        private IDatabaseProvider _dbProvider;

        public BusinessProvider(IDatabaseProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }
        public IQueryable<Contact> GetContacts()
        {
            try
            {
                return _dbProvider.GetContacts();
            }
            catch
            {
                throw;
            }
        }

        public Contact GetContact(int id)
        {
            try
            {
                return _dbProvider.GetContact(id);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                _dbProvider.UpdateContact(contact);
            }
            catch
            {
                throw;
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                _dbProvider.AddContact(contact);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                _dbProvider.DeleteContact(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
