using DataAccessLibrary.Models;
using DataModel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Angular4Core2.Controllers
{
    public class ContactController : Controller
    {
        private IContactHandler _contactHdl = new ContactHandler(new EntityRepository<Contact>(new ContactDBContext()));

        [HttpGet, Produces("application/json")]
        public IActionResult GetContacts()
        {
            var data = _contactHdl.GetAllContact();
            return Json(new { result = data });
        }

        [HttpPost, Produces("application/json")]
        public IActionResult SaveContact([FromBody] Contact model)
        {
            return Json(_contactHdl.SaveContact(model));
        }

        [HttpDelete]
        public IActionResult DeleteContactByID(int id)
        {
            return Json(_contactHdl.DeleteContactByID(id));
        }

    }
}