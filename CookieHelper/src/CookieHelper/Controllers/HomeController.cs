using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieHelper.Helpers;
using CookieHelper.Enums;
using CookieHelper.Models;

namespace CookieHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICookieHelp cookieHelper;
        public HomeController(ICookieHelp cookieHelper)
        {
            this.cookieHelper = cookieHelper;
        }
        public IActionResult Index()
        {
            

            return View();
        }

        [HttpGet]
        public IActionResult ProcessAction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessAction(ProcessViewModel model)
        {
            cookieHelper.SetCookie("test value", CookieKeys.ProcessKey);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
