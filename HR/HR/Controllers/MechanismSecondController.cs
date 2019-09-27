using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using Model;
using IBLL;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MechanismSecondController : Controller
    {

        IMechanismSecondBLL imb = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");

        IMechanismThirdBLL imb2 = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        // GET: MechanismSecond
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMSs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismSecondSelect()));
        }

        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        public ActionResult Add(MechanismSecondModel ms)
        {
            if (imb.MechanismSecondAdd(ms) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToAdd");
            }
        }


        public ActionResult ToUpdate(int id)
        {
            MechanismSecondModel ms = imb.MechanismSecondBy(id);
            return View(ms);
        }

        public ActionResult Update(MechanismSecondModel ms)
        {
            if (imb.MechanismSecondUpdate(ms) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToUpdate");
            }
        }

        public ActionResult Delete(int id)
        {
            if (imb2.MechanismThirdSelectSecond(imb.MechanismSecondBy(id).SecondMid).Count > 0)
            {
                return Content("have");
            }
            else
            {
                return Content(imb.MechanismSecondDelete(id).ToString());
            }
        }

    }
}