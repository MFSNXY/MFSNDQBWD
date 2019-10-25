﻿using System;
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
        IView_UserBLL iub = IocContainer.IocCreate.CreateBLL<IView_UserBLL>("View_UserBLL");
        IUsersBLL iul = IocContainer.IocCreate.CreateBLL<IUsersBLL>("UsersBLL");
        IUsersmanBLL ius = IocCreate.CreateBLL<IUsersmanBLL>("UsersmanBLL");
        IView_UserBLL ivb = IocCreate.CreateBLL<IView_UserBLL>("View_UserBLL");
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }


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
        public ActionResult Add()
        {
            List<UsersmanModel> list = ius.UsersmanSelect();
            SelectList sl = new SelectList(list, "U_oid", "U_name1", 1);
            ViewBag.s = sl;
            return View();
        }
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
        public ActionResult Update(int id)
        {
            List<UsersModel> um = iul.SelectUsersBy(id);
            List<UsersmanModel> list = ius.UsersmanSelect();
            SelectList sl = new SelectList(list, "U_oid", "U_name1", 1);
            ViewBag.s = sl;
            return View(um[0]);
        }
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
        public ActionResult DengLu()
        {
            return View();
        }
        public ActionResult Dl(string uid,string pid)
        {
            UsersModel um = iul.Dl(uid, pid);
            if (um != null)
            {
                Session["user"] = ivb.SelectView_UserBy(um.U_id)[0];
                Session["userRid"] = um.U_oid;
                return Content("<script>location.href = '/Home/Index';</script>");
            }
            else
            {
                return Content("<script>alert('登陆失败!');location.href = '/Users/DengLu';</script>");
            }
        }


        public ActionResult GetUsers()
        {
            return Content(JsonConvert.SerializeObject(iul.UsersSelect()));
        }


    }
}