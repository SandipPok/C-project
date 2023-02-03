using Microsoft.AspNetCore.Mvc;

namespace Lab26.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            string key = "MyCookie";
            string value = "Cookie Example";
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append(key, value, cookie);

            return View("Index");
        }
        public IActionResult Read()
        {
            string key = "MyCookie";
            var cookieValue = Request.Cookies[key];

            return View("Index");
        }
        public IActionResult Remove()
        {
            string key = "MyCookie";
            string value = "";
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookie);
            return View("Index");
        }
    }
}
