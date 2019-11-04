using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using IocContainer;

namespace HR.Controllers
{
    public class StandardDetailsController : Controller
    {
        IStandardDetailsBLL isb = IocContainer.IocCreate.CreateBLL<IStandardDetailsBLL>("StandardDetailsBLL");
        // GET: StandardDetails
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取所有薪酬项目
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            List<StandardDetailsModel> list = isb.StandardDetailsSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 薪酬项目添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 薪酬项目添加
        /// </summary>
        /// <param name="sd"></param>
        /// <returns></returns>
        [ActionName("ad")]
        public ActionResult Adds(StandardDetailsModel sd)
        {
            if (isb.StandardDetailsAdd(sd)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(sd);
            }
        }
        /// <summary>
        /// 薪酬项目删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Del(int id)
        {
            StandardDetailsModel sd = new StandardDetailsModel();
            sd.item_id = id;
            if (isb.StandardDetailsDelete(sd) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}