using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using IocContainer;
using Model;
using System.Data;
using System.Web.Caching;

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
        public ActionResult Index2(int PageSize, int currentPage)
        {
            int rows = 0;
            Cache ch = this.HttpContext.Cache;
            List<UsersmanModel> list = null;
            if (ch["curr"] == null)
            {
                ch["curr"] = currentPage;
            }
            if (ch["userlist"] == null|| (int)ch["curr"] != currentPage)
            {
                ch["curr"] = currentPage;
                list = iub.UsersmanFenYe(currentPage, PageSize, out rows);
                ch.Insert("userlist", list, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
                ch.Insert("rows", rows, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            else
            {
                list = ch["userlist"] as List<UsersmanModel>;
                rows = (int)ch["rows"];
            }
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list }, {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }
        //public ActionResult GetRow()
        //{
        //    int rows = 0;
        //    iub.UsersmanFenYe(1, 4, out rows);
        //    return Content(rows + "");
        //}
        public ActionResult Add()
        {
            return View();
        }
        [ActionName("ad")]
        public ActionResult Adds(UsersmanModel um)
        {
            if (iub.UsersmanAdd(um) > 0)
            {
                Cache ch = this.HttpContext.Cache;
                ch.Remove("userlist");
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
                Cache ch = this.HttpContext.Cache;
                ch.Remove("userlist");
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
            List<QxModel> list = list = ipb.qx(id,RoleID);
            return Content(JsonConvert.SerializeObject(list));
        }
        [ActionName("up")]
        public ActionResult XiuGai(UsersmanModel um)
        {
            if (iub.UsersmanUpdate(um) > 0)
            {
                string[] str = Request["rid"].Split(',');
                int cot = 0;
                bool flag = false;
                int t = 0;
                if (iab.AuthorityroleSel(um.U_oid)>0)
                {
                    t= iab.AuthorityroleDel(um.U_oid);
                    flag = true;
                }
                if ((flag&&t>0)||(!flag))
                {
                    foreach (var item in str)
                    {
                        AuthorityroleModel rp = new AuthorityroleModel();
                        rp.Aut_id = item;
                        rp.U_oid = um.U_oid.ToString();
                        if (iab.AuthorityroleAdd(rp) > 0)
                        {
                            cot++;
                        }
                    }
                    if (cot == str.Length)
                    {
                        Cache ch = this.HttpContext.Cache;
                        ch.Remove("userlist");
                        Response.Write(1);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Response.Write(0);
                        return RedirectToAction("Update", um.U_oid);
                    }
                }
                else
                {
                    return RedirectToAction("Update", um.U_oid);
                }
            }
            else
            {
                return RedirectToAction("Update", um.U_oid);
            }

        }
    }
}