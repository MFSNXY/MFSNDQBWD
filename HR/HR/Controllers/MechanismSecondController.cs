using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using Model;
using IBLL;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MechanismSecondController : Controller
    {

        IMechanismSecondBLL imb = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");

        IMechanismThirdBLL imb2 = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        // GET: MechanismSecond
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取二级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMSs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismSecondSelect()));
        }

        /// <summary>
        /// 二级机构添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        /// <summary>
        /// 二级机构添加
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public ActionResult Add(MechanismSecondModel ms)
        {
            if (imb.MechanismSecondAdd(ms) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToAdd");
            }
        }

        /// <summary>
        /// 二级机构修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ToUpdate(int id)
        {
            MechanismSecondModel ms = imb.MechanismSecondBy(id);
            return View(ms);
        }

        /// <summary>
        /// 二级机构修改
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public ActionResult Update(MechanismSecondModel ms)
        {
            if (imb.MechanismSecondUpdate(ms) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToUpdate");
            }
        }

        /// <summary>
        /// 二级机构删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            if (imb2.MechanismThirdSelectSecond(imb.MechanismSecondBy(id).SecondMid).Count > 0)
            {
                return Content("have");
            }
            else
            {
                return Content(imb.MechanismSecondDelete(id).ToString());
            }
        }

    }
}