using DataLibrary.DataModel;
using System.Linq;

namespace DataLibrary.DataServices
{
    public interface IContactHandler
    {
        IQueryable<Contact> GetAllContact();
        bool SaveContact(Contact model);
        bool DeleteContactByID(int id);
    }

    public class ContactHandler : IContactHandler
    {
        private IEntityRepository<Contact> _repository;

        public ContactHandler(IEntityRepository<Contact> repository)
        {
            _repository = repository;
        }

        public IQueryable<Contact> GetAllContact()
        {
            return _repository.GetAll();
        }

        public bool SaveContact(Contact entity)
        {
            Contact contact = _repository.GetAll(filter: x => x.ContactId == entity.ContactId).FirstOrDefault();
            if (contact == null)
            {
                return _repository.Insert(contact);
            }
            else
            {
                return _repository.Update(contact);
            }
        }

        public bool DeleteContactByID(int id)
        {
            Contact contact = _repository.GetAll(filter: x => x.ContactId == id).FirstOrDefault();
            if (contact != null)
            {
                return _repository.Insert(contact);
            }
            return false;
        }
    }
}
