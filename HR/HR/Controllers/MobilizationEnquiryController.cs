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
        public ActionResult dcx(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            TempData["mkid"] = FirstMid;
            TempData["mid"] = SecondMid;
            TempData["gjz"] = ThirdMid;
            TempData["zwfl"] = HumanMajorKindId;
            TempData["zwmc"] = HumanMajorId;
            TempData["stateTime"] = startTime;
            TempData["endTime"] = endTime;
            return View("list");
        }
        public ActionResult list(int currentPage,int pageSize,string mkid = "", string mid = "", string gjz = "", string zwfl = "", string zwmc = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            int rows = 0;
            List<Major_changeModel> list = imc.Major_changeSelectDcx(currentPage, pageSize,out rows, mkid, mid, gjz, zwfl, zwmc, startTime, endTime);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult detail(int id)
        {
            List<Major_changeModel> list = imc.SelectMajor_changeBy(id);
            return View(list[0]);
        }
    }
}