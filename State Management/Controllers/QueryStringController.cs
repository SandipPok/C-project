using Microsoft.AspNetCore.Mvc;
using Lab26.Models;

namespace Lab26.Controllers
{
    public class QueryStringController : Controller
    {
        public IActionResult GetQueryString(string name, int age)
        {
            User newUser = new User()
            {
                Name = name,
                Age = age
            };

            return View(newUser);
        }
    }
}
