using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC.Web.Areas.Control.Controllers
{
    public class HomeController : Controller
    {
        // GET: Control/Home
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}