using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBO.Interfaces
{    public interface IContactBO
    {
        bool isContactExists(int id);
        bool SaveContactInfo(Contact contact);
        Contact GetContactInfo(int id);
        List<Contact> GetContactListInfo();
        Models.Contact UpdateContactInfo(Models.Contact contact);
        bool DeactivateContactInfo(int id);
    }
}
