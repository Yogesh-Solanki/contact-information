using ContactInformationClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformationClient.ApiAccessLayer
{
    public class ApiCaller
    {
        //Hosted web API REST Service base url  
        private string Baseurl = "http://localhost:62199/";

        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                List<Contact> contacts = new List<Contact>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/Contacts/GetAll/true");
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = response.Content.ReadAsStringAsync().Result;
                        contacts = JsonConvert.DeserializeObject<List<Contact>>(stringResponse);
                    }
                    return contacts;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Contact> GetContact(int id)
        {
            try
            {
                Contact contact = new Contact();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(string.Format("api/Contacts/Get/{0}", id));
                    if (response.IsSuccessStatusCode)
                    {
                        var contactResponse = response.Content.ReadAsStringAsync().Result;
                        contact = JsonConvert.DeserializeObject<Contact>(contactResponse);
                        if (contact != null)
                        {
                            contact.ErrorCode = 0;
                            contact.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            contact.ErrorCode = 1;
                            contact.ErrorMessage = "Contact information not found.";
                        }
                    }
                    else
                    {
                        contact.ErrorCode = 1;
                        contact.ErrorMessage = "Unable to get contact information.";
                    }
                    return contact;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseBase> AddContact(Contact contact)
        {
            try
            {
                var responseBase = new ResponseBase();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/Contacts/Add/Contact", content);
                    if (response.IsSuccessStatusCode)
                    {
                        responseBase.ErrorCode = 0;
                        responseBase.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        responseBase.ErrorCode = 1;
                        responseBase.ErrorMessage = "Error occured during adding contact information";
                    }
                    return responseBase;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseBase> UpdateContact(Contact contact)
        {
            try
            {
                var responseBase = new ResponseBase();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(string.Format("api/Contacts/Update/{0}", contact.Id), content);
                    if (response.IsSuccessStatusCode)
                    {
                        responseBase.ErrorCode = 0;
                        responseBase.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        responseBase.ErrorCode = 1;
                        responseBase.ErrorMessage = "Error occured during updating contact information";
                    }
                    return responseBase;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseBase> DeleteContact(int id)
        {
            try
            {
                var responseBase = new ResponseBase();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.DeleteAsync(string.Format("api/Contacts/Delete/{0}", id));
                    if (response.IsSuccessStatusCode)
                    {
                        responseBase.ErrorCode = 0;
                        responseBase.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        responseBase.ErrorCode = 1;
                        responseBase.ErrorMessage = "Error occured during deleting contact information";
                    }
                    return responseBase;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}