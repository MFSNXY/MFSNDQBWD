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
            List<Major_changeModel> list = imc.Major_changeSelectSh(currentPage, pageSize,out rows);
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
        public ActionResult check_success()
        {
            return View();
        }
        [ActionName("up")]
        public ActionResult Update(Major_changeModel mc)
        {
            Major_changeModel mcm = imc.SelectMajor_changeBy(mc.Mch_id)[0];
            mcm.Checker = mc.Checker;
            mcm.Check_time = DateTime.Now;
            mcm.Check_reason = mc.Check_reason;
            mcm.Check_status = mc.Check_status;
            if (mcm.Check_status==1)
            {
                if (imc.Major_changeUpdate(mcm)>0)
                {
                    return View("check_success");
                }
                else
                {
                    return View(mcm);
                }
            }
            else
            {
                return View("check_list");
            }
        }
    }
}