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

            /// <summary>
            /// 简历登记页面
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public ActionResult Index(int id=0)
        {
            //判断是否申请了职位
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

        /// <summary>
        /// 简历登记
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 简历筛选页面
        /// </summary>
        /// <returns></returns>
        public ActionResult JLSX()
        {
            return View();
        }

        /// <summary>
        /// 简历筛选条件
        /// </summary>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="GJZ"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public ActionResult GetEngageResumeSX(string HumanMajorKindId="",string HumanMajorId="",string GJZ="",DateTime? StartTime=null,DateTime? EndTime=null)
        {
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = GJZ;
            TempData["StartTime"] = StartTime;
            TempData["EndTime"] = EndTime;
            return View();
        }

        /// <summary>
        /// 获取筛选后的简历列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="GJZ"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 简历复核明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult FH(int id)
        {
            return View(ierb.EngageResumeSelectBy(id));
        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 简历复核
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
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
                return Content("<script>alert('复核成功');location='/EngageResume/JLSX';</script>");
            }
            else
            {
                return Content("<script>alert('复核失败');</script>");
            }

        }
        /// <summary>
        /// 有效简历筛选页面
        /// </summary>
        /// <returns></returns>
        public ActionResult YXSX()
        {
            return View();
        }

        /// <summary>
        /// 有效筛选条件
        /// </summary>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="GJZ"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public ActionResult GetEngageResumeYXSX(string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = GJZ;
            TempData["StartTime"] = StartTime;
            TempData["EndTime"] = EndTime;
            return View();
        }

        /// <summary>
        /// 获取所有有效简历列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="GJZ"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 简历明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult JLXX(int id)
        {
            return View(ierb.EngageResumeSelectBy(id));
        }


    }
}