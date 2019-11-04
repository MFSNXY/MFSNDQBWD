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

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public ActionResult Index2(int PageSize, int currentPage)
        {
            int rows = 0;
            Cache ch = this.HttpContext.Cache;
            List<UsersmanModel> list = null;
            //判断是否存入角色列表
            if (ch["curr"] == null)
            {
                ch["curr"] = currentPage;
            }
            //是否存在角色列表，是否更改页码
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

        /// <summary>
        /// 角色添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="um"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 角色修改明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            List<UsersmanModel> list = iub.SelectUsersmanBy(id);
            return View(list[0]);
        }

        /// <summary>
        /// 按角色查询所拥有的权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SelectPid(int RoleID, int id = 0)
        {
            List<QxModel> list = list = ipb.qx(id,RoleID);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="um"></param>
        /// <returns></returns>
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
                //修改角色权限
                if ((flag&&t>0)||(!flag))
                {
                    //循环添加权限
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