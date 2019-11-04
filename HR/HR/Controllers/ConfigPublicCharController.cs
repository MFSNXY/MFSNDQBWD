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
    public class ConfigPublicCharController : Controller
    {
        // GET: ConfigPublicChar
        IConfigPublicCharBLL isb = IocContainer.IocCreate.CreateBLL<IConfigPublicCharBLL>("ConfigPublicCharBLL");
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有职称
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            string zwlx = "职称";
            List<ConfigPublicCharModel> list = isb.ConfigMajorKindStudentBy(zwlx);
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 删除职称
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public ActionResult Del(ConfigPublicCharModel cm)
        {
            ConfigPublicCharModel ck = new ConfigPublicCharModel();
            ck.Id = cm.Id;

            if (isb.ConfigPublicCharDelete(ck) > 0)
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