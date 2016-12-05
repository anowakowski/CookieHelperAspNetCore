using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieHelper.Helpers;
using CookieHelper.Models;
using CookieHelper.Enums;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CookieHelper.Controllers
{
    public class ProcessController : Controller
    {
        private readonly ICookieHelp cookieHelper;
        public ProcessController(ICookieHelp cookieHelper)
        {
            this.cookieHelper = cookieHelper;
        }
        // GET: /<controller>/
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
            if (ModelState.IsValid)
            {
                var dataInJson = JsonConvert.SerializeObject(model).ToString();

                cookieHelper.SetCookie(dataInJson, CookieKeys.ProcessKey);

                return RedirectToAction("ProcessActionType");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ProcessActionType()
        {
            var value = cookieHelper.GetCookie(CookieKeys.ProcessKey);

            var deserializedCookieValue = JsonConvert.DeserializeObject<ProcessViewModel>(value);

            var model = new ProcessTypeViewModel { ProcessTypeName = deserializedCookieValue.ProcessTypeName };

            return View(model);
        }

        [HttpPost]
        public IActionResult ProcessActionType(ProcessTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                cookieHelper.DeleteCookie(CookieKeys.ProcessKey);
            }

            return View("SuccessView");
        }
    }
}
