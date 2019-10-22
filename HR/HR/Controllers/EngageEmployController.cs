using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using BLL;
using Newtonsoft.Json;
using Model;

namespace HR.Controllers
{
    public class EngageEmployController : Controller
    {
        IHumanFileBLL ihf = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");

        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");

        IEngageInterviewBLL ieib = IocCreate.CreateBLL<IEngageInterviewBLL>("EngageInterviewBLL");
        // GET: EngageEmploy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEngageEmployLYSQ(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYSQ(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult GoEngageEmploySQ(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

        public ActionResult EngageEmploySQ(int id,string PassCheckComment)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            er.PassCheckComment = PassCheckComment;
            if (ierb.EngageResumeUpdate(er) > 0)
            {
                return Content("<script>alert('提交成功!');location='/EngageEmploy/Index';</script>");
            }
            else
            {
                return Content("<script>alert('提交失败!');</script>");
            }
        }


        public ActionResult LYSP()
        {
            return View();
        }

        public ActionResult GetEngageEmployLYSP(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYSP(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult GoEngageEmploySP(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

        public ActionResult EngageEmploySP(int id, string PassPassComment)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            er.PassPassComment = PassPassComment;
            //if (er.PassPassComment == "通过")
            //{
            //    HumanFileModel hf = new HumanFileModel()
            //    {
            //        HumanId = "HF" + DateTime.Now.ToString("yyMMddssfff") + new Random().Next(100, 999),
            //        HumanPicture = er.HumanPicture,
            //        HumanName = er.HumanName,
            //        HumanAddress=er.HumanAddress,
            //        HumanPostcode=er.HumanPostcode,
            //        HumanMajorKindId=er.HumanMajorKindId,
            //        HumanMajorKindName=er.HumanMajorKindName,
            //        HumanMajorId=er.HumanMajorId,
            //        HumanMajorName=er.HumanMajorName,
            //        HumanTelephone=er.HumanTelephone,
            //        HumanMobilephone=er.HumanMobilephone,
            //        HumanEmail=er.HumanEmail,
            //        HumanHobby=er.HumanHobby,
            //        HumanSpecility=er.HumanSpecility,
            //        HumanSex=er.HumanSex,
            //        HumanReligion=er.HumanReligion,
            //        HumanParty=er.HumanParty,
            //        HumanNationality=er.HumanNationality,
            //        HumanRace=er.HumanRace,
            //        HumanBirthday=er.HumanBirthday,
            //        HumanAge=er.HumanAge,
            //        HumanEducatedDegree=er.HumanEducatedDegree,
            //        HumanEducatedYears=er.HumanEducatedYears,
            //        HumanEducatedMajor=er.HumanEducatedMajor,
            //        Remark=er.Remark,
            //        HumanIdcard=er.HumanIdcard
            //    };
            //    ihf.HumanFileAdd(hf);
            //}
            if (ierb.EngageResumeUpdate(er) > 0)
            {
                return Content("<script>alert('提交成功!');location='/EngageEmploy/LYSP';</script>");
            }
            else
            {
                return Content("<script>alert('提交失败!');</script>");
            }
        }

        public ActionResult LYCX()
        {
            return View();
        }

        public ActionResult GetEngageEmployLYCX(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYCX(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult EngageEmployLYCX(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

    }
}