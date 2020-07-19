using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactDiaryBO.Interfaces
{
    public interface IContacDiarytBO
    {
        bool isContactExists(int id);
        bool SaveContactInfo(Contact contact);
        Contact GetContactInfo(int id);
        List<Contact> GetContactListInfo();
        bool UpdateContactInfo(Contact contact);
        bool DeactivateContactInfo(int id);
    }
}
