using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using IocContainer;

namespace HR.Controllers
{
    public class StandardDetailsController : Controller
    {
        IStandardDetailsBLL isb = IocContainer.IocCreate.CreateBLL<IStandardDetailsBLL>("StandardDetailsBLL");
        // GET: StandardDetails
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            List<StandardDetailsModel> list = isb.StandardDetailsSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
        public ActionResult Add()
        {
            return View();
        }
        [ActionName("ad")]
        public ActionResult Adds(StandardDetailsModel sd)
        {
            if (isb.StandardDetailsAdd(sd)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(sd);
            }
        }
        public ActionResult Del(int id)
        {
            StandardDetailsModel sd = new StandardDetailsModel();
            sd.Item_id = id;
            if (isb.StandardDetailsDelete(sd) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}