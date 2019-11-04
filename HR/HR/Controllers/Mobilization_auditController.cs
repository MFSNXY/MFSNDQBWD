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
        IHumanFileBLL ihb = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");
        // GET: Mobilization_audit
        public ActionResult check_list()
        {
            return View();
        }
        /// <summary>
        /// 获取待审核的调动列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 调动审核明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult check(int id)
        {
            List<Major_changeModel> list = imc.SelectMajor_changeBy(id);
            return View(list[0]);
        }

        /// <summary>
        /// 调动审核成功
        /// </summary>
        /// <returns></returns>
        public ActionResult check_success()
        {
            return View();
        }

        /// <summary>
        /// 调动审核
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
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
                //审核通过
                HumanFileModel hf = ihb.HumanFileByid(mc.Human_id);
                hf.FirstMid = mcm.New_first_kind_id;
                hf.FirstMName = mcm.New_first_kind_name;
                hf.SecondMid = mcm.New_second_kind_id;
                hf.SecondMName = mcm.New_second_kind_name;
                hf.ThirdMid = mcm.New_third_kind_id;
                hf.ThirdMName = mcm.New_third_kind_name;
                hf.HumanMajorId = mcm.New_major_id;
                hf.HumanMajorName = mcm.New_major_name;
                hf.HumanMajorKindId = mcm.New_major_kind_id;
                hf.HumanMajorKindName = mcm.New_major_kind_name;
                hf.SalaryStandardId = mcm.New_salary_standard_id;
                hf.SalaryStandardName = mcm.New_salary_standard_name;
                hf.SalarySum = mcm.New_salary_sum;
                if (imc.Major_changeUpdate(mcm)>0&&ihb.HumanFileUp(mc.Human_id)>0&&ihb.HumanFileUpdate(hf)>0)
                {
                    return View("check_success");
                }
                else
                {
                    return View("check?id="+mcm.Mch_id);
                }
            }
            else
            {
                //审核不通过
                if (imc.Major_changeDelete(mcm) > 0) {
                    return View("check_success");
                }
                else { 
                    return View("check_list");
                }
            }
        }
    }
}