using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppCore.Extensions;
using WebAppCore.Models;

namespace WebAppCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Jerateep");
            HttpContext.Session.SetInt32("Id", 123456789);
            List<string> lstData = new List<string>
            {
                "A","B","C"
            };
            HttpContext.Session.SetObjectAsJson("LstData", lstData);
            return View();
        }
        public IActionResult Show()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Id = HttpContext.Session.GetInt32("Id");
            List<string> LstData = HttpContext.Session.GetObjectFromJson<List<string>>("LstData");
            ViewBag.LstData = LstData;

            return View();
        }
        public IActionResult SetCookies()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(7)
            };
            Response.Cookies.Append("Test", "Test Test", cookieOptions);
            return View();
        }

        public IActionResult ShowCookies()
        {
            ViewBag.CookiesValue = HttpContext.Request.Cookies["Test"];
            return View();
        }


        [HttpGet]
        public IActionResult GetNumber(int _num)
        {
            ViewBag.Number = _num + 1;
            return PartialView();
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
