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

            if (!ModelState.IsValid)
            { return Json(ModelState.First()); }

            return Json(true);
        }       
    }
}