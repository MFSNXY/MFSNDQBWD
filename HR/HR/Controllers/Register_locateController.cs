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
        IConfigMajorKindBLL ickb = IocCreate.CreateBLL<IConfigMajorKindBLL>("ConfigMajorKindBLL");
        // GET: Register_locate
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 获取所有一级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            return Content(JsonConvert.SerializeObject(imb3.MechanismFirstSelect()));
        }
        /// <summary>
        /// 按一级机构获取二级机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMSsWhereFirst(string id)
        {
            return Content(JsonConvert.SerializeObject(imb2.MechanismSecondSelectFirst(id)));
        }
        /// <summary>
        /// 按一级机构和二级机构获取三级机构
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult GetMTs(string fid, string sid)
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelectFS(fid, sid)));
        }

        /// <summary>
        /// 调动登记筛选条件
        /// </summary>
        /// <param name="mkid"></param>
        /// <param name="mid"></param>
        /// <param name="gjz"></param>
        /// <param name="stateTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ActionResult register_list(string mkid="", string mid="", string gjz="", DateTime? stateTime=null, DateTime? endTime=null)
        {
            TempData["mkid"] = mkid;
            TempData["mid"] = mid;
            TempData["gjz"] = gjz;
            TempData["stateTime"] = stateTime;
            TempData["endTime"] = endTime;
            return View();
        }
        /// <summary>
        /// 获取调动登记列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="GJZ"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 调动登记明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult register(int id)
        {
            HumanFileModel hm = ihb.HumanFileBy(id);  
            return View(hm);
        }
        /// <summary>
        /// 获取职位分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index3()
        {
            return Content(JsonConvert.SerializeObject(ickb.ConfigMajorKindSelect()));
        }
        /// <summary>
        /// 按职位分类获取职位名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMs(string id)
        {
            return Content(JsonConvert.SerializeObject(icb.ConfigMajorSelectMKId(id)));
        }
        /// <summary>
        /// 调动条件
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 调动登记成功
        /// </summary>
        /// <returns></returns>
        public ActionResult register_success()
        {
            return View();
        }

        /// <summary>
        /// 获取薪酬标准列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Xc()
        {
            List<SalaryStandardModel> list = isb.SalaryStandardSelect();
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}