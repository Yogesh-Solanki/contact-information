using ContactInformationLibrary.Entity;
using ContactInformationLibrary.Interface;
using NLog;
using System;
using System.Data.Entity;
using System.Linq;

namespace ContactInformationLibrary.DatabaseLayer
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private AppDbContext context = new AppDbContext();

        public IQueryable<Contact> GetContacts()
        {
            try
            {
                return context.Contacts.Where(x => x.Status == true);
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API DataAccessLayer: Error occured while getting all contacts.", ex);
                throw ex;
            }
        }

        public Contact GetContact(int id)
        {
            try
            {
                Contact contact = context.Contacts.Find(id);
                return contact;
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API DataAccessLayer: Error occured while getting contact.", ex);
                throw ex;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                context.Entry(contact).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API DataAccessLayer: Error occured while updating contact.", ex);
                throw ex;
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API DataAccessLayer: Error occured while adding contact.", ex);
                throw ex;
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                Contact contact = context.Contacts.Find(id);
                contact.Status = false; //soft delete contact
                context.Entry(contact).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogException(LogLevel.Error, "API DataAccessLayer: Error occured while deleting contact.", ex);
                throw ex;
            }
        }
    }
}
