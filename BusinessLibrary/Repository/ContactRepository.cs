using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLibrary.Model;
using System.Linq;

namespace BusinessLibrary
{
    public class ContactRepository : IContactRepository
    {
        public async Task<List<ContactModel>> GetAllContact()
        {
            using (ContactDBContext db = new ContactDBContext())
            {
                return await (from a in db.Contact
                              select new ContactModel
                              {
                                  ContactId = a.ContactId,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  Email = a.Email,
                                  Phone = a.Phone
                              }).ToListAsync();

            }
        }

        public async Task<bool> SaveContact(ContactModel model)
        {
            using (ContactDBContext db = new ContactDBContext())
            {
                Contact contact = db.Contact.Where(x => x.ContactId == model.ContactId).FirstOrDefault();
                if (contact == null)
                {
                    contact = new Contact()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Phone = model.Phone
                    };
                    db.Contact.Add(contact);

                }
                else
                {
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.Email = model.Email;
                    contact.Phone = model.Phone;
                }

                return await db.SaveChangesAsync() >= 1;
            }
        }

        public async Task<bool> DeleteContactByID(int id)
        {
            using (ContactDBContext db = new ContactDBContext())
            {

                Contact contact = db.Contact.Where(x => x.ContactId == id).FirstOrDefault();
                if (contact != null)
                {
                    db.Contact.Remove(contact);
                }
                return await db.SaveChangesAsync() >= 1;
            }
        }
    }
}
