using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class ConfigMajorKindController : Controller
    {
        // GET: ConfigMajorKind
        //IConfigMajorKindBLL isb = IocContainer.IocCreate.CreateBLL<IConfigMajorKindBLL>("ConfigMajorKindBLL");
        public IConfigMajorKindBLL isb { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            List<ConfigMajorKindModel> list = isb.ConfigMajorKindSelect();
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult Create()
        {
            return View();
        }

        [ActionName("ad")]
        public ActionResult Create(ConfigMajorKindModel sm)
        {
            if (isb.ConfigMajorKindAdd(sm) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

        public ActionResult Del(ConfigMajorKindModel cm)
        {
            ConfigMajorKindModel ck = new ConfigMajorKindModel();
            ck.Id = cm.Id;

            if (isb.ConfigMajorKindDelete(ck) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}