using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using BLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MechanismFirstController : Controller
    {
        IMechanismFirstBLL imb = IocCreate.CreateBLL<IMechanismFirstBLL>("MechanismFirstBLL");

        IMechanismSecondBLL imb2 = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");

        IMechanismThirdBLL imb3 = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        // GET: MechanismFirst
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMFs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismFirstSelect()));
        }

        public ActionResult DeleteMF(int id)
        {
            if (imb2.MechanismSecondSelectFirst(imb.MechanismFirstBy(id).FirstMId).Count>0||imb3.MechanismThirdSelectFirst(imb.MechanismFirstBy(id).FirstMId).Count>0)
            {
                return Content("have");
            }
            else
            {
                return Content(imb.MechanismFirstDelete(id).ToString());
            }
        }


        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        public ActionResult Add(MechanismFirstModel mf)
        {
            if (imb.MechanismFirstAdd(mf)>0) {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToAdd");
            }
        }


        public ActionResult ToUpdate(int id)
        {
            MechanismFirstModel mf = imb.MechanismFirstBy(id);
            return View(mf);
        }

        public ActionResult Update(MechanismFirstModel mf)
        {
            if (imb.MechanismFirstUpdate(mf) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToUpdate");
            }
        }


    }
}