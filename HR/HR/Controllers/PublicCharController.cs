using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class PublicCharController : Controller
    {
        IPublicCharBLL ipb = IocContainer.IocCreate.CreateBLL<IPublicCharBLL>("PublicCharBLL");
        // GET: PublicChar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            List<PublicCharModel> list = ipb.PublicCharSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
        public ActionResult Add()
        {
            return View();
        }
        [ActionName("ad")]
        public ActionResult Adds(PublicCharModel pm)
        {
            if (ipb.PublicCharAdd(pm)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pm);
            }
        }
        public ActionResult Del(int id)
        {
            PublicCharModel pc = new PublicCharModel();
            pc.Pbc_id = id;
            if (ipb.PublicCharDelete(pc) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetPCs(string type)
        {
            return Content(JsonConvert.SerializeObject(ipb.PublicCharGet(type)));
        }


    }
}