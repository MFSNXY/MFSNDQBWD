using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using IBLL;
using IocContainer;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MobilizationEnquiryController : Controller
    {
        IMajor_changeBLL imc = IocCreate.CreateBLL<IMajor_changeBLL>("Major_changeBLL");
        // GET: MobilizationEnquiry
        public ActionResult locate()
        {
            return View();
        }
        [ActionName("cx")]
        public ActionResult dcx(string mkid="", string mid="", string gjz="", string zwfl="", string zwmc="", DateTime? startTime=null, DateTime? endTime=null)
        {
            TempData["mkid"] = mkid;
            TempData["mid"] = mid;
            TempData["gjz"] = gjz;
            TempData["zwfl"] = zwfl;
            TempData["zwmc"] = zwmc;
            TempData["stateTime"] = startTime;
            TempData["endTime"] = endTime;
            return View("list");
        }
        public ActionResult list(string mkid = "", string mid = "", string gjz = "", string zwfl = "", string zwmc = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            List<Major_changeModel> list = imc.Major_changeSelectDcx(mkid, mid, gjz, zwfl, zwmc, startTime, endTime);
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult detail(int id)
        {
            List<Major_changeModel> list = imc.SelectMajor_changeBy(id);
            return View(list[0]);
        }
    }
}