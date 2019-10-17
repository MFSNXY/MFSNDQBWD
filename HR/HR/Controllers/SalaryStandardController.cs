using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class SalaryStandardController : Controller
    {
        // GET: SalaryStandard

        ISalaryStandardBLL isb = IocContainer.IocCreate.CreateBLL<ISalaryStandardBLL>("SalaryStandardBLL");
        IStandardDetailsBLL idb = IocContainer.IocCreate.CreateBLL<IStandardDetailsBLL>("StandardDetailsBLL"); 
        ISalaryStandardDetailsBLL isd = IocContainer.IocCreate.CreateBLL<ISalaryStandardDetailsBLL>("SalaryStandardDetailsBLL");

        //薪酬标准登记 
        public ActionResult Create()
        {
            return View();

        }
        //查出复选框
        public ActionResult Project()
        {
            List<StandardDetailsModel> list = idb.StandardDetailsSelect();
            return Content(JsonConvert.SerializeObject(list));
        }

        //产生薪酬标准编号 
        public ActionResult BianHao()
        {
            string dh = "13533" + DateTime.Now.Year + DateTime.Now.Minute + DateTime.Now.Second; ;
            return Content(dh);
        }

        //
        public ActionResult DenjiCG()
        {
            return View();
        }

        public ActionResult Add()
        {
            //基本信息
            SalaryStandardModel ssm = new SalaryStandardModel();
            ssm.Standardid = Request["Standardid"];
            ssm.Standardname = Request["Standardname"];
            ssm.Salarysum = Convert.ToDecimal(Request["Salarysum"]);
            ssm.Designer = Request["Designer"];
            ssm.Register = Request["Register"];
            ssm.Registtime = DateTime.Parse(Request["Registtime"]);
            ssm.Remark = Request["Remark"];
            int r1 = isb.SalaryStandardAdd(ssm);
            //详情信息
            string arry = Request["arry"];
            List<Dictionary<string, object>> sdm = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(arry);
            int r2 = 0;
            foreach (var item in sdm)
            {
                SalaryStandardDetailsModel sd = new SalaryStandardDetailsModel();
                sd.Itemid = int.Parse(item["id"].ToString());
                sd.Itemname = item["names"].ToString();
                sd.Standardid = Request["Standardid"];
                sd.Standardname = Request["Standardname"];
                sd.Salary = Convert.ToDecimal(item["money"]);
                if (isd.SalaryStandardDetailsAdd(sd) > 0)
                {
                    r2++;
                }
            }
            string flag = "false";
            if (r1 > 0 && r2 == sdm.Count)
            {
                flag = "true";
            }
            return Content(flag);
        }

        //薪酬标准登记复核
        public ActionResult Checklist()
        {
            return View();
        }

        public ActionResult DJFH(int currentPage, int pageSize)
        {
            int rows = 0;
            int z = currentPage;
            int s = pageSize;
            return Content(JsonConvert.SerializeObject(isb.SalaryStandardSelectFY(currentPage, pageSize, out rows)));
        }
        public ActionResult GetRow()
        {
            int rows = 0;
            isb.SalaryStandardSelectFY(1, 4, out rows);
            return Content(rows + "");
        }

        public ActionResult Check(int id)
        {
            List<SalaryStandardModel> list = isb.SalaryStandardSelectBy(id);
            SalaryStandardModel ck = list[0];
            string dh = ck.Standardid;
            List<SalaryStandardDetailsModel> list2 = isd.SalaryGrantdetailsSelectSID(dh);
            ViewBag.list2 = list2;
            return View(ck);
        }

        public ActionResult xg()
        {
            SalaryStandardModel sg = new SalaryStandardModel();
            sg.Id = Convert.ToInt32(Request["Id"]);
            sg.Salarysum =Convert.ToDecimal(Request["Salarysum"]);
            sg.Checker= Request["Checker"];
            sg.Checktime = Convert.ToDateTime(Request["Checktime"]);
            sg.Checkcomment = Request["Checkcomment"];

           int r1 = isb.SalaryStandardUpdate(sg);

            string arry = Request["arry"];
            List<Dictionary<string, object>> sdm = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(arry);
            int r2 = 0;
            foreach (var item in sdm)
            {
                SalaryStandardDetailsModel sm = new SalaryStandardDetailsModel();
                sm.Id = int.Parse(item["Id"].ToString());
                sm.Salary = Convert.ToDecimal(item["money"]);

                if (isd.SalaryStandardDetailsUpdate(sm) > 0)
                {
                    r2++;
                }

            }
            string flag = "false";
            if (r1 > 0 && r2 == sdm.Count)
            {
                flag = "true";
            }
            return Content(flag);
        }

        //薪酬标准查询
        public ActionResult QuertLocate()
        {
            return View();
        }

        public ActionResult XCFFCX(string Standardid = "", string GJZ = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            TempData["Standardid"] = Standardid;
            TempData["GJZ"] = GJZ;
            TempData["startDate"] = startDate;
            TempData["endDate"] = endDate;
            return View();
        }

        public ActionResult XCFFCX2(int currentPage, int pageSize, string Standardid = "", string GJZ = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            int rows = 0;
            List<SalaryStandardModel> list = isb.SalaryStandardFYW(currentPage, pageSize, out rows, Standardid, GJZ, startDate, endDate);
            TempData["rows"] = rows;
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetRow2()
        {

            return Content(TempData["rows"].ToString());
        }
    }
}