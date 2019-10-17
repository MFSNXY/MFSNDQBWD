using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using Model;
using Newtonsoft.Json;
using System.Data;

namespace HR.Controllers
{
    public class UsersmanController : Controller
    {
        IUsersmanBLL iub = IocCreate.CreateBLL<IUsersmanBLL>("UsersmanBLL");
        IPermissionBLL ipb = IocCreate.CreateBLL<IPermissionBLL>("PermissionBLL");
        IAuthorityroleBLL iab = IocCreate.CreateBLL<IAuthorityroleBLL>("AuthorityroleBLL");
        // GET: Usersman
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2(int PageSize = 2, int currentPage = 1)
        {
            int rows = 0;
            return Content(JsonConvert.SerializeObject(iub.UsersmanFenYe(currentPage, PageSize, out rows)));
        }
        public ActionResult GetRow()
        {
            int rows = 0;
            iub.UsersmanFenYe(1, 4, out rows);
            return Content(rows + "");
        }
        public ActionResult Add()
        {
            return View();
        }
        [ActionName("ad")]
        public ActionResult Adds(UsersmanModel um)
        {
            if (iub.UsersmanAdd(um) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(um);
            }
        }
        public ActionResult Del(int id)
        {
            UsersmanModel um = new UsersmanModel();
            um.U_oid = id;
            if (iub.UsersmanDelete(um) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(um);
            }
        }
        public ActionResult Update(int id)
        {
            List<UsersmanModel> list = iub.SelectUsersmanBy(id);
            TempData["js"] = list[0].U_oid;
            return View(list[0]);
        }
        public ActionResult SelectPid(int RoleID, int id = 0)
        {
            //List<PermissionModel> list = new List<PermissionModel>();
            //DataTable dt = new DataTable();
            //if (Request["id"]==null)
            //{
            //    list = ipb.qx(0,(int)TempData["js"]);
            //}
            //else
            //{
            //    list = ipb.qx(Convert.ToInt32(Request["id"]), Convert.ToInt32(TempData["js"]));
            //}
            List<PermissionModel> list = list = ipb.qx(id,RoleID);
            return Content(JsonConvert.SerializeObject(list));
        }
        [ActionName("up")]
        public ActionResult XiuGai(UsersmanModel um)
        {
            if (iub.UsersmanUpdate(um) > 0)
            {
                string i = TempData["js"].ToString();
                string[] str = Request["rid"].Split(',');
                int cot = 0;
                int t = ipb.PermissionDelete(int.Parse(i));
                if (t > 0)
                {
                    foreach (var item in str)
                    {
                        AuthorityroleModel rp = new AuthorityroleModel();
                        rp.Aut_id = i;
                        rp.U_oid = item;
                        if (iab.AuthorityroleAdd(rp) > 0)
                        {
                            cot++;
                        }
                    }
                    if (cot == str.Length)
                    {
                        Response.Write(1);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Response.Write(0);
                        return View(um);
                    }
                }
                else
                {
                    return View(um);
                }
            }
            else
            {
                return View(um);
            }

        }
    }
}