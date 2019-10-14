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
using System.Transactions;

namespace HR.Controllers
{
    public class EngageInterviewController : Controller
    {

        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");

        IEngageInterviewBLL ieib = IocCreate.CreateBLL<IEngageInterviewBLL>("EngageInterviewBLL");

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
            EngageInterviewModel eim = ieib.EngageInterviewSelectResumeId(id);
            ViewBag.InterviewCount = 1;
            if (eim != null)
            {
                ViewBag.InterviewCount = eim.InterviewCount + 1;
                ViewBag.EIid = eim.Id;
            }
            return View(ierb.EngageResumeSelectBy(id));
        }

        public ActionResult EngageInterviewRegister(EngageInterviewModel eim)
        {
            bool flag = false;
            if (eim.Id>1)
            {
                flag = ieib.EngageInterviewUpdate(eim) > 0 ? true : false;
            }
            else
            {
                flag = ieib.EngageInterviewAdd(eim) > 0 ? true : false;
            }
            if (flag)
            {
                return Content("<script>alert('登记成功!');location='/EngageInterview/Index';</script>");
            }
            else
            {
                return Content("<script>alert('登记失败!');</script>");
            }
        }

        public ActionResult EngageInterviewSX()
        {
           return View();
        }

        public ActionResult GetEngageInterviewSX(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageInterviewModel> list = ieib.EngageInterviewMSSX(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult EngageInterviewMSSX(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string,object> dic=new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

        public ActionResult SX(int id,string Result,string Checker,DateTime CheckTime,string CheckComment)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            int InterviewStatus = 0;
            switch (Result)
            {
                case "建议面试":
                    InterviewStatus = 1;
                    break;
                case "建议笔试":
                    InterviewStatus = 2;
                    break;
                case "建议录用":
                    InterviewStatus = 3;
                    break;
                case "删除简历":
                    InterviewStatus = 4;
                    break;
            }
            er.InterviewStatus = InterviewStatus;
            ei.Result = Result;
            ei.Checker = Checker;
            ei.CheckTime = CheckTime;
            ei.CheckComment = CheckComment;
            using(TransactionScope tr =new TransactionScope())
            {
                if (ierb.EngageResumeUpdate(er) > 0 && ieib.EngageInterviewUpdate(ei)>0)
                {
                    tr.Complete();
                    return Content("<script>alert('筛选成功!');location='/EngageInterview/EngageInterviewSX';</script>");
                }
            }
            return Content("<script>alert('筛选失败!');location='/EngageInterview/EngageInterviewMSSX?id="+id+"';</script>");
        }


    }
}