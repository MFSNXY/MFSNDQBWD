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
    public class ConfigMajorKindController : Controller
    {
        // GET: ConfigMajorKind
        //IConfigMajorKindBLL isb = IocContainer.IocCreate.CreateBLL<IConfigMajorKindBLL>("ConfigMajorKindBLL");
        public IConfigMajorKindBLL isb { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有职位分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            List<ConfigMajorKindModel> list = isb.ConfigMajorKindSelect();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 职位分类添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 职位分类添加
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        [ActionName("ad")]
        public ActionResult Create(ConfigMajorKindModel sm)
        {
            if (isb.ConfigMajorKindAdd(sm) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

        /// <summary>
        /// 职位分类删除
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public ActionResult Del(ConfigMajorKindModel cm)
        {
            ConfigMajorKindModel ck = new ConfigMajorKindModel();
            ck.Id = cm.Id;

            if (isb.ConfigMajorKindDelete(ck) > 0)
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