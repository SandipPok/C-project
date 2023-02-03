using Microsoft.AspNetCore.Mvc;
using Lab26.Models;

namespace Lab26.Controllers
{
    public class HiddenFieldController : Controller
    {
        [HttpGet]
        public IActionResult SetHiddenFieldValue()
        {
            User newUser = new User()
            {
                Name = "John",
                Age = 24
            };
            return View(newUser);
        }
        [HttpPost]
        public IActionResult SetHiddenFieldValue(IFormCollection keyValues)
        {
            var name = keyValues["name"];
            return View();
        }
    }
}
