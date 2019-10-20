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
    public class EngageController : Controller
    {
        IMechanismThirdBLL imb = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        IEngageBLL ieb = IocCreate.CreateBLL<IEngageBLL>("EngageBLL");

        IConfigMajorBLL icb = IocCreate.CreateBLL<IConfigMajorBLL>("ConfigMajorBLL");
        
        // GET: Engage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToAddEngageRelease()
        {
            return View();
        }

        public ActionResult GetMTs(string fid,string sid)
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelectFS(fid, sid)));
        }

        public ActionResult AddEngageRelease(EngageModel em)
        {
            em.ChangeTime = DateTime.Now;
            if (ieb.EngageAdd(em)>0)
            {
                return Content("<script>alert('添加成功');location='../Engage/ToAddEngageRelease';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');location='../Engage/ToAddEngageRelease';</script>");
            }
        }

        public ActionResult SelectUpdate()
        {
            return View();
        }
        public ActionResult GetEngages(int currentPage,int pageSize)
        {
            int rows = 0;
            return Content(JsonConvert.SerializeObject(ieb.EngageFY(currentPage, pageSize, out rows)));
        }

        public ActionResult GetRow()
        {
            int rows = 0;
            ieb.EngageFY(1, 4, out rows);
            return Content(rows+"");
        }

        public ActionResult Delete(int id)
        {
            return Content(ieb.EngageDelete(id).ToString());
        }

        public ActionResult ToUpdate(int id)
        {
            return View(ieb.EngageBy(id));
        }

        public ActionResult Update(EngageModel em)
        {
            if (ieb.EngageUpdate(em) > 0)
            {
                return Content("<script>alert('修改成功!');location='/Engage/SelectUpdate';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败!');</script>");
            }
        }

        public ActionResult SelectFB()
        {
            return View();
        }

        public ActionResult GetMs(string id)
        {
            return Content(JsonConvert.SerializeObject(icb.ConfigMajorSelectMKId(id)));
        }


    }
}