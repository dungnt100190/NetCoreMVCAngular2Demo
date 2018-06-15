using BusinessLibrary;
using BusinessLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2MVC.Controllers
{
    //[Route("api/Contact")]
    public class ContactController : Controller
    {
        public IContactRepository ContactRepo;

        public ContactController(IContactRepository contactRepo)
        {
            ContactRepo = contactRepo;
        }

        [HttpGet, Produces("application/json")]
        public async Task<IActionResult> GetContacts()
        {
            var data = await ContactRepo.GetAllContact();
            return Json(new { result = data });
        }

        [HttpPost, Produces("application/json")]
        public async Task<IActionResult> SaveContact([FromBody] ContactModel model)
        {
            return Json(await ContactRepo.SaveContact(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContactByID(int id)
        {
            return Json(await ContactRepo.DeleteContactByID(id));
        }

        //private readonly IContactHandler contactHandler = new ContactHandler(new EntityRepository<Contact>(new ContactDBContext()));

        //// GET: api/Contact/GetAllContact
        //[HttpGet("[action]")]
        //public IEnumerable<dynamic> GetAllContact()
        //{
        //    IEnumerable<Contact> data = contactHandler.GetAllContact();
        //    return data;
        //}

        //// POST api/Contact/SaveContact
        //[HttpPost]
        //public bool SaveContact([FromBody]Contact model)
        //{
        //    return contactHandler.SaveContact(model);
        //}

        //// DELETE api/Contact/DeleteContact/id
        //[HttpDelete("{id}")]
        //public bool DeleteContact(int id)
        //{
        //    return contactHandler.DeleteContactByID(id);
        //}
    }
}
