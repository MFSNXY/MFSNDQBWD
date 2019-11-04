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
    public class UsersController : Controller
    {
        //IView_UserBLL iub = IocContainer.IocCreate.CreateBLL<IView_UserBLL>("View_UserBLL");
        public IView_UserBLL iub { get; set; }
        //IUsersBLL iul = IocContainer.IocCreate.CreateBLL<IUsersBLL>("UsersBLL");
        public IUsersBLL iul { get; set; }
        //IUsersmanBLL ius = IocCreate.CreateBLL<IUsersmanBLL>("UsersmanBLL");
        public IUsersmanBLL ius { get; set; }
        //IView_UserBLL ivb = IocCreate.CreateBLL<IView_UserBLL>("View_UserBLL");
        public IView_UserBLL ivb { get; set; }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index2(int currentPage,int pageSize)
        {
            int rows = 0;
            List<View_UserModel> list = iub.View_UserFenYe<View_UserModel>(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        /// <summary>
        /// 用户添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            List<UsersmanModel> list = ius.UsersmanSelect();
            SelectList sl = new SelectList(list, "U_oid", "U_name1", 1);
            ViewBag.s = sl;
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="um"></param>
        /// <returns></returns>
        [ActionName("ad")]
        public ActionResult Adds(UsersModel um)
        {
            if (iul.UsersAdd(um) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(um);
            }
        }

        /// <summary>
        /// 用户修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            List<UsersModel> um = iul.SelectUsersBy(id);
            List<UsersmanModel> list = ius.UsersmanSelect();
            SelectList sl = new SelectList(list, "U_oid", "U_name1", 1);
            ViewBag.s = sl;
            return View(um[0]);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="um"></param>
        /// <returns></returns>
        [ActionName("up")]
        public ActionResult Updates(UsersModel um)
        {
            if (iul.UsersUpdate(um)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(um);
            }
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Del(int id)
        {
            UsersModel um = new UsersModel();
            um.U_id = id;
            if (iul.UsersDelete(um)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(um);
            }
        }

        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DengLu()
        {
            return View();
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult Dl(string uid,string pid)
        {
            UsersModel um = iul.Dl(uid, pid);
            if (um != null)
            {
                if (um.U_oid == 30)
                {
                    Session["SHuser"] = ivb.SelectView_UserBy(um.U_id)[0];
                    Session["SHRid"] = um.U_oid;
                    return Content("2");
                }
                else
                {
                    Session["user"] = ivb.SelectView_UserBy(um.U_id)[0];
                    Session["userRid"] = um.U_oid;
                    return Content("1");
                }
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUsers()
        {
            return Content(JsonConvert.SerializeObject(iul.UsersSelect()));
        }


    }
}