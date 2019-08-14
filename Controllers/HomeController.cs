using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private List<Dictionary<string, object>> AllUsers
        {
            get
            {
                return DbConnector.Query("SELECT * FROM users;");
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult quotes(string name, string quote)
        {
            string query = $"INSERT INTO users (name, quote) VALUES ('{name}', '{quote}');";
            DbConnector.Execute(query);
            return RedirectToAction("quotes");
        }

        [HttpGet("quotes")]
        public IActionResult quotes()
        {
            return View("Quotes", AllUsers);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
