using ContactBO.Interfaces;
using ContactDiaryDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBO
{
    public class ContactBO : IContactBO
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
            var iMapper = Mapping.MappingProfile.GetMapper();
            var result = _contactDataAccess.GetContactById(id);
            if (result != null)
            {
                var contactModel = iMapper.Map<Models.Contact>(result);                
                contactModel.Status = false;
                contactModel.ModifiedDate = DateTime.Now;
                _contactDataAccess.SaveContactInfo(iMapper.Map<ContactDiaryDataAccess.Contact>(contactModel));

                return true;
            }
            return false;
        }

        public Models.Contact GetContactInfo(int id)
        {
            var iMapper = Mapping.MappingProfile.GetMapper();
            var result = _contactDataAccess.GetContactById(id);
            if(result != null)
            {
                return iMapper.Map<Models.Contact>(result);
            }
            return null;
        }

        public List<Models.Contact> GetContactListInfo()
        {
            List<Models.Contact> resultContactList = new List<Models.Contact>();
            var iMapper = Mapping.MappingProfile.GetMapper();
            var contactList = _contactDataAccess.GetContacts();
            foreach (var item in contactList)
            {                
                resultContactList.Add(iMapper.Map<Models.Contact>(item));
            }
            return resultContactList;
        }

        public bool isContactExists(int id)
        {
            var contact = _contactDataAccess.GetContactById(id);
            return contact != null;
        }

        public bool SaveContactInfo(Models.Contact contactModel)
        {
            var iMapper = Mapping.MappingProfile.GetMapper();
            var contact = iMapper.Map<ContactDiaryDataAccess.Contact>(contactModel);
            return _contactDataAccess.SaveContactInfo(contact);
        }

        public Models.Contact UpdateContactInfo(Models.Contact contact)
        {
            var iMapper = Mapping.MappingProfile.GetMapper();
            var result = _contactDataAccess.GetContactById(contact.ID);
            if (result != null)
            {
                var contactModel = iMapper.Map<Models.Contact>(result);
                contactModel.FirstName = contact.FirstName;
                contactModel.LastName = contact.LastName;
                contactModel.Email = contact.Email;
                contactModel.PhoneNumber = contact.PhoneNumber;
                contactModel.Status = contact.Status;
                contactModel.ModifiedDate = DateTime.Now;
                _contactDataAccess.SaveContactInfo(iMapper.Map<ContactDiaryDataAccess.Contact>(contactModel));

                return contactModel;
            }
            return null;
        }
    }
}
