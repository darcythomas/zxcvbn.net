using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        public ActionResult SignIn(SignIn signin)
        {
            return View();
        }
	}
}