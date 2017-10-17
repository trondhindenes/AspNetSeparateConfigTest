using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace SeparateConfigTest.Controllers
{

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {

            var appConfig = (KeyValueConfigurationCollection)HttpContext.Application["CustomAppConfig"];
            //var myEnv = appConfig['MyEnvironment'];
            
            var myEnv = appConfig["MyEnvironment"].Value;
            ViewBag.Title = myEnv;

            return View();
        }
    }
}
