using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class PublicCharController : Controller
    {
        IPublicCharBLL ipb = IocContainer.IocCreate.CreateBLL<IPublicCharBLL>("PublicCharBLL");
        // GET: PublicChar
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有公共属性
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            List<PublicCharModel> list = ipb.PublicCharSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 公共属性添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 公共属性添加
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        [ActionName("ad")]
        public ActionResult Adds(PublicCharModel pm)
        {
            if (ipb.PublicCharAdd(pm)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pm);
            }
        }
        /// <summary>
        /// 公共属性删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Del(int id)
        {
            PublicCharModel pc = new PublicCharModel();
            pc.Pbc_id = id;
            if (ipb.PublicCharDelete(pc) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 按分类获取公共属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult GetPCs(string type)
        {
            return Content(JsonConvert.SerializeObject(ipb.PublicCharGet(type)));
        }


    }
}