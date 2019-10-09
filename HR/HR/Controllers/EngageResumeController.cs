using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using BLL;
using Model;

namespace HR.Controllers
{
    public class EngageResumeController : Controller
    {

        IMechanismFirstBLL imfb = IocCreate.CreateBLL<IMechanismFirstBLL>("MechanismFirstBLL");
        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");
        IEngageBLL ieb = IocCreate.CreateBLL<IEngageBLL>("EngageBLL");
        // GET: EngageResume
        public ActionResult Index(int id=0)
        {
            ViewBag.MajorKindid = 0;
            ViewBag.Majorid = "0";
            ViewBag.MajorKindName = "";
            ViewBag.MajorName = "";
            if (id > 0)
            {
                EngageModel em = ieb.EngageBy(id);
                ViewBag.MajorKindid = em.MajorKindid;
                ViewBag.Majorid = em.MajorId;
                ViewBag.MajorKindName = em.MajorKindName;
                ViewBag.MajorName = em.MajorName;
            }
            return View();
        }

        public ActionResult Add(EngageResumeModel er)
        {
            er.RegistTime = DateTime.Now;
            er.CheckTime = DateTime.Now;
            er.TestCheckTime = DateTime.Now;
            er.PassEegistTime = DateTime.Now;
            er.PassCheckTime = DateTime.Now;
            if (ierb.EngageResumeAdd(er)>0)
            {
                return Content("<script>alert('添加成功');location='../EngageResume/Index';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');location='../EngageResume/Index';</script>");
            }
            
        }

        public ActionResult JLSX()
        {
            return View();
        }

        public ActionResult GetEngageResumeSX(string HumanMajorKindId,string )
        {

        }

    }
}