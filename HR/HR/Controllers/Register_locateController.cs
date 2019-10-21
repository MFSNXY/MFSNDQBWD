using IBLL;
using IocContainer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace HR.Controllers
{
    public class Register_locateController : Controller
    {
        IMechanismThirdBLL imb = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        IMechanismSecondBLL imb2 = IocCreate.CreateBLL<IMechanismSecondBLL>("MechanismSecondBLL");
        IMechanismFirstBLL imb3 = IocCreate.CreateBLL<IMechanismFirstBLL>("MechanismFirstBLL");
        IMajor_changeBLL imc = IocCreate.CreateBLL<IMajor_changeBLL>("Major_changeBLL");
        IConfigMajorBLL icb = IocCreate.CreateBLL<IConfigMajorBLL>("ConfigMajorBLL");
        ISalaryStandardBLL isb = IocCreate.CreateBLL<ISalaryStandardBLL>("SalaryStandardBLL");
        IHumanFileBLL ihb = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");
        // GET: Register_locate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return Content(JsonConvert.SerializeObject(imb3.MechanismFirstSelect()));
        }
        public ActionResult GetMSsWhereFirst(string id)
        {
            return Content(JsonConvert.SerializeObject(imb2.MechanismSecondSelectFirst(id)));
        }
        public ActionResult GetMTs(string fid, string sid)
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelectFS(fid, sid)));
        }

        public ActionResult register_list(string mkid="", string mid="", string gjz="", DateTime? stateTime=null, DateTime? endTime=null)
        {
            TempData["mkid"] = mkid;
            TempData["mid"] = mid;
            TempData["gjz"] = gjz;
            TempData["stateTime"] = stateTime;
            TempData["endTime"] = endTime;
            return View();
        }
        public ActionResult YXJL(int currentPage, int pageSize, string HumanMajorKindId = "", string HumanMajorId = "", string GJZ = "", DateTime? StartTime = null, DateTime? EndTime = null)
        {
            int rows = 0;
            List<HumanFileModel> list = ihb.HumanFileSelectSX(currentPage, pageSize, out rows, HumanMajorKindId, HumanMajorId, GJZ, StartTime, EndTime);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }
        public ActionResult register(int id)
        {
            HumanFileModel hm = ihb.HumanFileBy(id);  
            return View(hm);
        }
        public ActionResult Index3()
        {
            return Content(JsonConvert.SerializeObject(icb.ConfigMajorSelect()));
        }
        public ActionResult GetMs(string id)
        {
            return Content(JsonConvert.SerializeObject(icb.ConfigMajorSelectMKId(id)));
        }
        [ActionName("up")]
        public ActionResult Update(Major_changeModel mc)
        {
            if (imc.Major_changeAdd(mc) > 0)
            {
                return View("register_success");
            }
            else
            {
                return View(mc);
            }
        }
        public ActionResult register_success()
        {
            return View();
        }

        public ActionResult Xc()
        {
            List<SalaryStandardModel> list = isb.SalaryStandardSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}