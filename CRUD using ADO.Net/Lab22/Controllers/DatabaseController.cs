using Lab22.Repository;
using Microsoft.AspNetCore.Mvc;
using Lab22.Models;
using System.Data.SqlClient;

namespace Lab22.Controllers
{
    public class DatabaseController : Controller
    {
        DatabaseConnect repo = new DatabaseConnect();
        public IActionResult Index()
        {
            IEnumerable<GetData> dataList = repo.GetData();
            return View(dataList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GetData gd)
        {
            try
            {
                repo.AddData(gd);
                return Content("Data has been inserted successfully!");
            }
            catch (Exception e)
            {
                return Content("OOPS! " + e.Message);
            }
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, GetData gd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(repo.conStr))
                {
                    string query = $"UPDATE Data SET Id = {gd.Id}, Name = '{gd.Name}', Gender = '{gd.Gender}' WHERE Id = {id}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return RedirectToAction("Index","Database");
            }
            catch (Exception e)
            {
                return Content("Opps!" + e.Message);
            }
        }
        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(repo.conStr))
            {
                string query = $"DELETE FROM Data WHERE Id = {id}";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("Index","Database");
        }
    }
}
