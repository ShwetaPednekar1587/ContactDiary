using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using ContactBO.Interfaces;
using ContactBO;

namespace ContactDiaryAPI.Controllers
{
    public class ContactController : ApiController
    {
        private IContactBO _contactBO;
        public ContactController() : this(new ContactBO.ContactBO())
        {

        }
        public ContactController(IContactBO contactBO)
        {
            _contactBO = contactBO;
        }
        public IEnumerable<Contact> Get()
        {
            return _contactBO.GetContactListInfo();
        }

        public Contact Get(int id)
        {
            return _contactBO.GetContactInfo(id);
        }

        public bool Post([FromBody]Contact contact)
        {           
            return _contactBO.SaveContactInfo(contact);
        }

        public Contact Put([FromBody]Contact contact)
        {
            return _contactBO.UpdateContactInfo(contact);
        }

        public bool Delete(int id)
        {
            return _contactBO.DeactivateContactInfo(id);
        }
    }
    }