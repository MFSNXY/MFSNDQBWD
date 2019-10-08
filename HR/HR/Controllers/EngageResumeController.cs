using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using BLL;
using Model;

namespace HR.Controllers
{
    public class EngageResumeController : Controller
    {

        IMechanismFirstBLL imfb = IocCreate.CreateBLL<IMechanismFirstBLL>("MechanismFirstBLL");
        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");
        // GET: EngageResume
        public ActionResult Index()
        {
            return View();
        }
    }
}