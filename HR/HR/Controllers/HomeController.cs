using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using BLL;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class HomeController : Controller
    {

        IPermissionBLL ipb = IocCreate.CreateBLL<IPermissionBLL>("PermissionBLL");
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTree(int id=0)
        {
            return Content(JsonConvert.SerializeObject(ipb.PermissionRole(id,0)));
        }


        public ActionResult Top()
        {
            return View();
        }



    }
}