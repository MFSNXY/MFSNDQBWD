using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using Model;
using BLL;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MechanismThirdController : Controller
    {

        IMechanismThirdBLL imb = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        IMechanismSecondBLL imb2 = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");
        // GET: MechanismThird
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取三级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMTs()
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelect()));
        }

        /// <summary>
        /// 三级机构添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ToAdd()
        {
            string mid = DateTime.Now.ToString("yyMMddmmss") + new Random().Next(100, 999);
            ViewBag.Mid = mid;
            return View();
        }

        /// <summary>
        /// 三级机构添加
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public ActionResult Add(MechanismThirdModel mt)
        {
            return Content(imb.MechanismThirdAdd(mt).ToString());
        }

        /// <summary>
        /// 三级机构修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ToUpdate(int id)
        {
            MechanismThirdModel mt = imb.MechanismThirdBy(id);
            return View(mt);
        }

        /// <summary>
        /// 三级机构修改
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public ActionResult Update(MechanismThirdModel mt)
        {
            if (imb.MechanismThirdUpdate(mt) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ToUpdate");
            }
        }

        /// <summary>
        /// 三级机构删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            return Content(imb.MechanismThirdDelete(id).ToString());
        }

        /// <summary>
        /// 按一级机构id获取二级机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMSsWhereFirst(string id)
        {
            return Content(JsonConvert.SerializeObject(imb2.MechanismSecondSelectFirst(id)));
        }


    }
}