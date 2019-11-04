using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using BLL;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class HomeController : Controller
    {

        IPermissionBLL ipb = IocCreate.CreateBLL<IPermissionBLL>("PermissionBLL");
        


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取按角色id获取所有的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetTree(int id=0)
        {
            List<PermissionModel> list = ipb.PermissionRole(id, ((int)Session["userRid"]));
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 顶部页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Checker()
        {
            Dictionary<string, List<object>> dic = new Dictionary<string, List<object>>();
            return View();
        }

        public ActionResult GetCheak()
        {

            return View();
        }

        public ActionResult Main()
        {

            return View();
        }

        public ActionResult CheckerMain()
        {

            return View();
        }

        public ActionResult Top2()
        {

            return View();
        }

        /// <summary>
        /// 获取审核人的权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSHPermissionRole()
        {
            List<PermissionModel> list = ipb.PermissionRole();
            return Content(JsonConvert.SerializeObject(list));
        }

    }
}