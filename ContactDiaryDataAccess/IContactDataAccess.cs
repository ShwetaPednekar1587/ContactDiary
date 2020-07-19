using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDiaryDataAccess
{
    public interface IContactDataAccess
    {
        List<Contact> GetContacts();
        Contact GetContactById(int id);
        bool SaveContactInfo(Contact contact);
    }
}
