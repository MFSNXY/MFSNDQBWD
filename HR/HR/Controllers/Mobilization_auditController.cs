using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using IocContainer;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class Mobilization_auditController : Controller
    {
        IMajor_changeBLL imc = IocCreate.CreateBLL<IMajor_changeBLL>("Major_changeBLL");
        // GET: Mobilization_audit
        public ActionResult check_list()
        {
            return View();
        }
        public ActionResult Index2(int currentPage,int pageSize)
        {
            int rows = 0;
            List<Major_changeModel> list = imc.Major_changeFenYe(currentPage, pageSize,out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }
        public ActionResult check(int id)
        {
            List<Major_changeModel> list = imc.SelectMajor_changeBy(id);
            return View(list[0]);
        }
    }
}