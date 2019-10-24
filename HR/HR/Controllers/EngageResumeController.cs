using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using BLL;
using Model;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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
            ViewBag.EngageId = 0;
            if (id > 0)
            {
                EngageModel em = ieb.EngageBy(id);
                ViewBag.MajorKindid = em.MajorKindid;
                ViewBag.Majorid = em.MajorId;
                ViewBag.MajorKindName = em.MajorKindName;
                ViewBag.MajorName = em.MajorName;
                ViewBag.EngageId = id;
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
            er.HumanPicture =(string)TempData["imgSrc"];
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

        public ActionResult GetEngageResumeSX(string HumanMajorKindId="",string HumanMajorId="",string GJZ="",DateTime? StartTime=null,DateTime? EndTime=null)
        {
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = GJZ;
            TempData["StartTime"] = StartTime;
            TempData["EndTime"] = EndTime;
            return View();
        }

        public ActionResult GetEngageResumeSXJL(int currentPage, int pageSize, string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            int rows = 0;
            List<EngageResumeModel> list=ierb.EngageResumeSelectSX(currentPage, pageSize, out rows,HumanMajorKindId, HumanMajorId, GJZ,StartTime, EndTime);
            TempData["rows"] = rows;
            return Content(JsonConvert.SerializeObject(list)); 
        }

        public ActionResult GetRow()
        {
            return Content(TempData["rows"].ToString());
        }

        public ActionResult FH(int id)
        {
            return View(ierb.EngageResumeSelectBy(id));
        }

        public ActionResult AddImage(HttpPostedFileBase file)
        {
            try {
                byte[] bts = MD5.Create().ComputeHash(file.InputStream);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bts)
                {
                    sb.Append(b.ToString("X2"));
                }
                string name = sb.ToString();
                string ext = Path.GetExtension(file.FileName);
                string path = Server.MapPath("~/Image/" + DateTime.Now.ToString("yyyy/MM/dd")) + "/" + name + ext;
                new FileInfo(path).Directory.Create();
                file.SaveAs(path);
                TempData["imgSrc"] = path;
            }
            catch (Exception)
            {
                return Content("0");
            }
            return Content("1");
        }

        public ActionResult EngageResumeFH(EngageResumeModel a)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(a.Id);
            er.CheckStatus = a.CheckStatus;
            er.PassCheckComment = a.PassCheckComment;
            er.PassPassComment=a.PassPassComment;
            er.InterviewStatus = a.InterviewStatus;
            er.Checker = a.Checker;
            er.TestCheckTime = DateTime.Now;
            er.PassEegistTime = DateTime.Now;
            er.PassCheckTime = DateTime.Now;
            if (ierb.EngageResumeUpdate(er) > 0)
            {
                return Content("<script>alert('复核成功');location='../EngageResume/JLSX';</script>");
            }
            else
            {
                return Content("<script>alert('复核失败');</script>");
            }

        }

        public ActionResult YXSX()
        {
            return View();
        }

        public ActionResult GetEngageResumeYXSX(string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = GJZ;
            TempData["StartTime"] = StartTime;
            TempData["EndTime"] = EndTime;
            return View();
        }

        public ActionResult GetEngageResumeYXJL(int currentPage, int pageSize, string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectYXSX(currentPage, pageSize, out rows, HumanMajorKindId, HumanMajorId, GJZ, StartTime, EndTime);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult JLXX(int id)
        {
            return View(ierb.EngageResumeSelectBy(id));
        }


    }
}