using ContactDiaryBO.Interfaces;
using ContactDiaryDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Mappers;

namespace ContactDiaryBO
{
    public class ContactBO : IContacDiarytBO
    {
        IContactDataAccess _contactDataAccess;

        public ContactBO() : this(new ContactDataAccess())
        {
        }

        public ContactBO(IContactDataAccess contactDataAccess)
        {
            _contactDataAccess = contactDataAccess;
        }
        public bool DeactivateContactInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Contact GetContactInfo(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.Contact> GetContactListInfo()
        {           
                List<Models.Contact> resultContactList = new List<Models.Contact>();
                var iMapper = Mapping.MappingProfile.GetMapper();
                var contactList = _contactDataAccess.GetContacts();
                foreach (var item in contactList)
                {
                    Models.Contact contact = new Models.Contact();
                    resultContactList.Add(iMapper.Map<Models.Contact>(item));
                }
                return resultContactList;           
            
        }

        public bool isContactExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveContactInfo(Models.Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContactInfo(Models.Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
