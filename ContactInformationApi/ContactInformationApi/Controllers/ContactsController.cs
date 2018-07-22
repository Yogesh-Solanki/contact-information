using ContactInformationApi.Mapper;
using ContactInformationApi.Models;
using ContactInformationLibrary.BusinessLayer;
using ContactInformationLibrary.Interface;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContactInformationApi.Controllers
{
    public class ContactsController : ApiController
    {
        private IBusinessProvider _businessProvider;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ContactMapper mapper = new ContactMapper();

        public ContactsController() { }

        public ContactsController(IBusinessProvider businessProvider)
        {
            _businessProvider = businessProvider;
        }


        [ResponseType(typeof(IEnumerable<Contact>))]
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            try
            {
                return mapper.DbEntitiesToListModel(_businessProvider.GetContacts());
            }
            catch(Exception ex)
            {
                logger.LogException(LogLevel.Error, "API Controller: Error in getting all contacts.", ex);
                throw ex;
            }
        }

        [ResponseType(typeof(Contact))]
        [HttpGet]
        public Contact Get(int id)
        {
            try
            {
                return mapper.DbEntityToModel(_businessProvider.GetContact(id));
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API Controller: Error in getting contact.", ex);
                throw ex;
            }
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        public void Update([FromBody] Contact contact)
        {
            try
            {
                _businessProvider.UpdateContact(mapper.ModelToDbEntity(contact));
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API Controller: Error in updating contact.", ex);
                throw ex;
            }
        }

        [ResponseType(typeof(void))]
        [HttpPost]
        public void Add([FromBody] Contact contact)
        {
            try
            {
                _businessProvider.AddContact(mapper.ModelToDbEntity(contact));
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API Controller: Error in adding contact.", ex);
                throw ex;
            }
        }

        [ResponseType(typeof(void))]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _businessProvider.DeleteContact(id);
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "API Controller: Error in deleting contact.", ex);
                throw ex;
            }
        }

    }
}