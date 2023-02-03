using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Xml.Linq;

namespace Lab26.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult First()
        {
            TempData["msg"] = "This message comes from TempData";
            return View();
        }
        public IActionResult Second()
        {
            string msg;

            if (TempData.ContainsKey("msg"))
                msg = TempData["msg"] as string;

            TempData.Keep("msg");

            return View();
        }
        public IActionResult Third()
        {
            string msg;

            if (TempData.ContainsKey("msg"))
                msg = TempData["msg"] as string;

            return View();
        }
    }
}
