using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using BLL;

namespace HR.Controllers
{
    public class EngageInterviewController : Controller
    {

        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");

        // GET: EngageInterview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EngageInterviewMSJG(string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = GJZ;
            TempData["StartTime"] = StartTime;
            TempData["EndTime"] = EndTime;
            return View();
        }

        public ActionResult GetEngageInterviewMSJG(int currentPage, int pageSize, string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectMSJL(currentPage, pageSize, out rows, HumanMajorKindId, HumanMajorId, GJZ, StartTime, EndTime);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult EngageInterviewDJ(int id)
        {
            return View(ierb.EngageResumeSelectBy(id));
        }

    }
}