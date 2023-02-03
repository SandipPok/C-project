using Microsoft.AspNetCore.Mvc;

namespace Lab26.Controllers
{
    public class SessionController : Controller
    {
        private readonly IHttpContextAccessor _context;

        public SessionController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }
        public IActionResult Index()
        {
            _context.HttpContext.Session.SetString("Name", "John");
            _context.HttpContext.Session.SetInt32("Age", 24);

            return View();
        }
    }
}
