using BusinessLibrary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAllContact();
        Task<bool> SaveContact(ContactModel model);
        Task<bool> DeleteContactByID(int id);
    }
}
