using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class ConfigMajorController : Controller
    {
        // GET: ConfigMajor
        //IConfigMajorBLL isb = IocContainer.IocCreate.CreateBLL<IConfigMajorBLL>("ConfigMajorBLL");
        public IConfigMajorBLL isb { get; set; }
        //IConfigMajorKindBLL ilb = IocContainer.IocCreate.CreateBLL<IConfigMajorKindBLL>("ConfigMajorKindBLL");
        public IConfigMajorKindBLL ilb { get; set; }

        /// <summary>
        /// 职位主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有职位
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            List<ConfigMajorModel> list = isb.ConfigMajorSelect();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 职位添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            List<ConfigMajorKindModel> list = ilb.ConfigMajorKindSelect();
            
            SelectList sl = new SelectList(list, "Majorkindid", "Majorkindname", 1);
            ViewBag.s = sl;
            ViewBag.bh = Convert.ToInt32(isb.GetBH()) + 1;
            return View();
        }

        /// <summary>
        /// 职位添加
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        [ActionName("ad")]
        public ActionResult Create(ConfigMajorModel sm)
        {
            sm.Majorkindname = ilb.fff(sm.Majorkindid);
            if (isb.ConfigMajorAdd(sm) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

        /// <summary>
        /// 职位删除
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public ActionResult Del(ConfigMajorModel cm)
        {
            ConfigMajorModel ck = new ConfigMajorModel();
            ck.Id = cm.Id;

            if (isb.ConfigMajorDelete(ck) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}