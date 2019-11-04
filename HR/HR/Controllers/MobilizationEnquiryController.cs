using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using IBLL;
using IocContainer;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class MobilizationEnquiryController : Controller
    {
        IMajor_changeBLL imc = IocCreate.CreateBLL<IMajor_changeBLL>("Major_changeBLL");
        // GET: MobilizationEnquiry
        public ActionResult locate()
        {
            return View();
        }
        /// <summary>
        /// 调动查询
        /// </summary>
        /// <param name="FirstMid"></param>
        /// <param name="SecondMid"></param>
        /// <param name="ThirdMid"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [ActionName("cx")]
        public ActionResult dcx(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            TempData["mkid"] = FirstMid;
            TempData["mid"] = SecondMid;
            TempData["gjz"] = ThirdMid;
            TempData["zwfl"] = HumanMajorKindId;
            TempData["zwmc"] = HumanMajorId;
            TempData["stateTime"] = startTime;
            TempData["endTime"] = endTime;
            return View("list");
        }
        /// <summary>
        /// 获取调动查询列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="mkid"></param>
        /// <param name="mid"></param>
        /// <param name="gjz"></param>
        /// <param name="zwfl"></param>
        /// <param name="zwmc"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ActionResult list(int currentPage,int pageSize,string mkid = "", string mid = "", string gjz = "", string zwfl = "", string zwmc = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            int rows = 0;
            List<Major_changeModel> list = imc.Major_changeSelectDcx(currentPage, pageSize,out rows, mkid, mid, gjz, zwfl, zwmc, startTime, endTime);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        /// <summary>
        /// 调动查询明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult detail(int id)
        {
            List<Major_changeModel> list = imc.SelectMajor_changeBy(id);
            return View(list[0]);
        }
    }
}