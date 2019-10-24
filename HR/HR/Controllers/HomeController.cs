﻿using System;
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

        public ActionResult GetTree(int id=0)
        {
            List<PermissionModel> list = ipb.PermissionRole(id, ((int)Session["userRid"]));
            return Content(JsonConvert.SerializeObject(list));
        }


        public ActionResult Top()
        {
            return View();
        }



    }
}