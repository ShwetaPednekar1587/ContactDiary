using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDiaryDataAccess
{
    public class ContactDataAccess : IContactDataAccess
    {
        public List<Contact> GetContacts()
        {
            using (ContactDBEntities entities = new ContactDBEntities())
            {
                return entities.Contacts.Where(x => x.Status).ToList();
            }
        }

        public Contact GetContactById(int id)
        {
            using (ContactDBEntities entities = new ContactDBEntities())
            {
                return entities.Contacts.Where(x => x.ID == id && x.Status).FirstOrDefault();
            }
        }

        public bool SaveContactInfo(Contact contact)
        {
            using (ContactDBEntities entities = new ContactDBEntities())
            {
                try
                {
                    entities.Contacts.Add(contact);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;  
                }                
            }
        }

    }
}
