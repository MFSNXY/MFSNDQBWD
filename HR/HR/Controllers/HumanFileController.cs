using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class HumanFileController : Controller
    {
        // GET: HumanFile
        public ActionResult HumanFileRegister()
        {
            return View();
        }

        public ActionResult HumanFilePicture()
        {
            return View();
        }

    }
}