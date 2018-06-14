using DataLibrary.DataModel;
using DataLibrary.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace Angular2MVC.Controllers
{
    public class ContactController : Controller
    {
        public IContactHandler contactHandler;

        public ContactController(IContactHandler contactRepo)
        {
            contactHandler = contactRepo;
        }

        [HttpGet, Produces("application/json")]
        public IActionResult GetContacts()
        {
            var data = contactHandler.GetAllContact();
            return Json(new { result = data });
        }

        [HttpPost, Produces("application/json")]
        public IActionResult SaveContact([FromBody] Contact model)
        {
            return Json(contactHandler.SaveContact(model));
        }

        [HttpDelete]
        public IActionResult DeleteContactByID(int id)
        {
            return Json(contactHandler.DeleteContactByID(id));
        }
    }
}
