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

namespace HR.Controllers
{
    public class MechanismFirstController : Controller
    {
        IMechanismFirstBLL imb = IocCreate.CreateBLL<IMechanismFirstBLL>("MechanismFirstBLL");

        IMechanismSecondBLL imb2 = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");

        IMechanismThirdBLL imb3 = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        // GET: MechanismFirst
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有的一级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMFs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismFirstSelect()));
        }

        /// <summary>
        /// 删除一级机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteMF(int id)
        {
            if (imb2.MechanismSecondSelectFirst(imb.MechanismFirstBy(id).FirstMId).Count>0||imb3.MechanismThirdSelectFirst(imb.MechanismFirstBy(id).FirstMId).Count>0)
            {
                return Content("have");
            }
            else
            {
                return Content(imb.MechanismFirstDelete(id).ToString());
            }
        }

        /// <summary>
        /// 一级机构添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        /// <summary>
        /// 一级机构添加
        /// </summary>
        /// <param name="mf"></param>
        /// <returns></returns>
        public ActionResult Add(MechanismFirstModel mf)
        {
            if (imb.MechanismFirstAdd(mf)>0) {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToAdd");
            }
        }

        /// <summary>
        /// 一级机构修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ToUpdate(int id)
        {
            MechanismFirstModel mf = imb.MechanismFirstBy(id);
            return View(mf);
        }

        /// <summary>
        /// 一级机构修改
        /// </summary>
        /// <param name="mf"></param>
        /// <returns></returns>
        public ActionResult Update(MechanismFirstModel mf)
        {
            if (imb.MechanismFirstUpdate(mf) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToUpdate");
            }
        }


    }
}