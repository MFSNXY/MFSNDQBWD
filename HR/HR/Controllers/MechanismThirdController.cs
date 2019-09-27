using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using Model;
using BLL;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MechanismThirdController : Controller
    {

        IMechanismThirdBLL imb = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");
        // GET: MechanismThird
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMTs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelect()));
        }

        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        public ActionResult Add(MechanismThirdModel mt)
        {
            if (imb.MechanismThirdAdd(mt) > 0)
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
            MechanismThirdModel mt = imb.MechanismThirdBy(id);
            return View(mt);
        }

        public ActionResult Update(MechanismThirdModel mt)
        {
            if (imb.MechanismThirdUpdate(mt) > 0)
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
            return Content(imb.MechanismThirdDelete(id).ToString());
        }


    }
}