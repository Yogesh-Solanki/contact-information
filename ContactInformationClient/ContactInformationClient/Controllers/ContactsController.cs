using ContactInformationClient.ApiAccessLayer;
using ContactInformationClient.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ContactInformationClient.Controllers
{
    public class ContactsController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ApiCaller apiCaller = new ApiCaller();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                TempData["GetContactRecordException"] = null;
                TempData["NoContactRecords"] = null;
                //Get contacts from Api
                contacts = await apiCaller.GetContacts();
                if (contacts == null || contacts.Count == 0)
                {
                    TempData["NoContactRecords"] = "Contact records not found.";
                }
                return View(contacts);
            }
            catch (Exception ex)
            {
                logger.LogException(LogLevel.Error, "Error occured in Contacts controller Index Action", ex);
                TempData["GetContactRecordException"] = "Something went wrong while getting contact records.";
                return View(contacts);
            }
        }

        
        // GET: Contacts/Add
        [HttpGet]
        public ActionResult Add()
        {
            Contact contact = new Contact();
            return View(contact);
        }


        // POST: Contacts/Add
        [HttpPost]
        public async Task<ActionResult> Add(Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await apiCaller.AddContact(model);
                    if (response.ErrorCode == 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        model.ErrorCode = response.ErrorCode;
                        model.ErrorMessage = response.ErrorMessage;
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                logger.LogException(LogLevel.Error, "Error occured in Contacts controller Add Post Action method", ex);
                model.ErrorCode = 1;
                model.ErrorMessage = "Something went wrong while adding contact.";
                return View(model);
            }
        }


        // GET: Contacts/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Contact contact = new Contact();
            try
            {
                contact = await apiCaller.GetContact(id);
                return View(contact);
            }
            catch (Exception ex)
            {
                //log exception here
                logger.LogException(LogLevel.Error, "Exception occured in Contacts/Edit get method", ex);
                contact.ErrorCode = 1;
                contact.ErrorMessage = "Something went wrong while getting contact information.";
                return View(contact);
            }
        }


        // Post: Contacts/Edit
        [HttpPost]
        public async Task<ActionResult> Edit(Contact model)
        {
            var responseBase = new ResponseBase();
            try
            {
                if (ModelState.IsValid)
                {
                    responseBase = await apiCaller.UpdateContact(model);
                    if (responseBase.ErrorCode == 0) {
                        return RedirectToAction("Index");
                    }
                    else{
                        model.ErrorCode = responseBase.ErrorCode;
                        model.ErrorMessage = responseBase.ErrorMessage;
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                logger.LogException(LogLevel.Error, "Error occured in Contacts controller Edit post action", ex);
                model.ErrorCode = 1;
                model.ErrorMessage = "Something went wrong while updating contact information.";
                return View(model);
            }
        }


        // DELETE: Contacts/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var responseBase = new ResponseBase();
            try
            {
                TempData["UnableToDeleteContact"] = null;
                responseBase = await apiCaller.DeleteContact(id);
                if (responseBase.ErrorCode != 0)
                    TempData["UnableToDeleteContact"] = "Unable to delete selected contact.";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.LogException(LogLevel.Error, "Exception occured in Contacts/Delete method", ex);
                TempData["UnableToDeleteContact"] = "Something went wrong while deleting contact.";
                return RedirectToAction("Index");
            }
        }
    }
}
