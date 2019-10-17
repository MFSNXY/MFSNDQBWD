using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class SalaryGrantController : Controller
    {
        // GET: SalaryGrant

        ISalaryGrantBLL isb = IocContainer.IocCreate.CreateBLL<ISalaryGrantBLL>("SalaryGrantBLL");
        ISalaryGrantdetailsBLL igb = IocContainer.IocCreate.CreateBLL<ISalaryGrantdetailsBLL>("SalaryGrantdetailsBLL");
        ISalaryStandardDetailsBLL ilb = IocContainer.IocCreate.CreateBLL<ISalaryStandardDetailsBLL>("SalaryStandardDetailsBLL");
        public ActionResult Index()
        {

            List<lei> list = new List<lei>();
            lei le = new lei();
            le.sid = 1;
            le.mc = "一级机构发放方式";
            list.Add(le);
            lei le2 = new lei();
            le2.sid = 2;
            le2.mc = "二级机构发放方式";
            list.Add(le2);
            lei le3 = new lei();
            le3.sid = 3;
            le3.mc = "三级机构发放方式";
            list.Add(le3);
            SelectList sl = new SelectList(list, "sid", "mc", 0);
            ViewBag.s = sl;
            return View();
        }
        public ActionResult Cha()
        {
            return View();
        }

        //I级机构
        public ActionResult YJJG()
        {
            return View();
        }
        public ActionResult YJJG2()
        {
            List<SalaryGrantModel> list = isb.SalaryGrantSelectYJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        //二级机构
        public ActionResult EJJG()
        {
            return View();
        }
        public ActionResult EJJG2()
        {
            List<SalaryGrantModel> list = isb.SalaryGrantSelectEJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        //三级机构
        public ActionResult SJJG()
        {
            return View();
        }
        public ActionResult SJJG2()
        {
            List<SalaryGrantModel> list = isb.SalaryGrantSelectSJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        [ActionName("ad")]
        public ActionResult Cha(lei sm)
        {
          
            int i = sm.sid;
            //string w = sm.mc;
            //return View();   
            if (i==1)
            {
                return RedirectToAction("YJJG");
            }
            else if (i==2)
            {
                return RedirectToAction("EJJG");
            }
            else if (i == 3)
            {
                return RedirectToAction("SJJG");
            }
            else
            {
                return View();
            }
            //if (isb.ConfigMajorAdd(sm) > 0)
            //{

            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View();
            //}

        }



        public ActionResult zz()
        {
            return View();
        }

        public ActionResult Commit(string id,int sid,string name)
        {
            ViewBag.Humanamount = name;
            ViewBag.id = id;
            ViewBag.sid = sid;
            return View();
        }

        public ActionResult Check(string id, int sid)
        {
            ViewBag.id = id;
            ViewBag.sid = sid;
            return View();
        }

        public ActionResult Commit2(string Salarygrantid,int Id)
        {
            
            string sgid = Salarygrantid;
            int sid1=Id;
            List<SalaryGrantdetailsModel> list = igb.SalaryGrantdetailsSelectID(sgid);
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult Commit3(string Humanid)
        {

            string sid = Humanid;
            List<SalaryStandardDetailsModel> list = ilb.SalaryGrantdetailsSelectGZXQ(sid);
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult registersuccess()
        {
            return View();
        }

        public ActionResult ckeckstersuccess()
        {
            return View();
        }

        public ActionResult xg()
        {
           

            SalaryGrantModel sg = new SalaryGrantModel();
            sg.Id =Convert.ToInt32(Request["Id"]);
            sg.Register = Request["Register"];
            sg.Registtime =Convert.ToDateTime(Request["Registtime"]);
            sg.Checker = Request["Checker"];
            sg.Checktime = DateTime.Now;
            sg.Checkstatus = 2;
            int r1 = isb.SalaryGrantUpdate(sg);

            string arry = Request["arry"];
            List<Dictionary<string, object>> sdm = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(arry);
            int r2 = 0;
            foreach (var item in sdm)
            {
                SalaryGrantdetailsModel sm = new SalaryGrantdetailsModel();
                sm.Id = int.Parse(item["Id"].ToString());
                sm.Bounssum = Convert.ToDecimal(item["Bounssum"]);
                sm.Salesum = Convert.ToDecimal(item["Salesum"]);
                sm.Deductsum = Convert.ToDecimal(item["Deductsum"]);
                sm.Salarypaidsum = Convert.ToDecimal(item["Salarypaidsum"]);
                if (igb.SalaryGrantdetailsUpdate(sm) > 0)
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

        public ActionResult xg2()
        {
            SalaryGrantModel sg = new SalaryGrantModel();
            sg.Id = Convert.ToInt32(Request["Id"]);
            sg.Register = Request["Register"];
            sg.Registtime = DateTime.Now;
            sg.Checker = Request["Checker"];
            sg.Checktime = Convert.ToDateTime(Request["Checktime"]);
            sg.Checkstatus =3;
            int r1 = isb.SalaryGrantUpdate(sg);

            string arry = Request["arry"];
            List<Dictionary<string, object>> sdm = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(arry);
            int r2 = 0;
            foreach (var item in sdm)
            {
                SalaryGrantdetailsModel sm = new SalaryGrantdetailsModel();
                sm.Id = int.Parse(item["Id"].ToString());
                sm.Bounssum = Convert.ToDecimal(item["Bounssum"]);
                sm.Salesum = Convert.ToDecimal(item["Salesum"]);
                sm.Deductsum = Convert.ToDecimal(item["Deductsum"]);
                sm.Salarypaidsum = Convert.ToDecimal(item["Salarypaidsum"]);
                if (igb.SalaryGrantdetailsUpdate(sm) > 0)
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

        //薪酬发放登记复核 
        public ActionResult SelectFH()
        {
            return View();
        }
        
        public ActionResult DJFH(int currentPage, int pageSize)
        {
            int rows = 0;
            int z = currentPage;
            int s = pageSize;
            return Content(JsonConvert.SerializeObject(isb.SalaryGrantFY(currentPage, pageSize, out rows)));
        }
        public ActionResult GetRow()
        {
            int rows = 0;
            isb.SalaryGrantFY(1, 4, out rows);
            return Content(rows + "");
        }

        //薪酬发放查询
        public ActionResult Querlocate()
        {
            return View();
        }

        public ActionResult XCFFCX(string Salarystandardid = "", string GJZ="", DateTime? startDate=null, DateTime? endDate=null)
        {
            TempData["Salarystandardid"] = Salarystandardid;
            TempData["GJZ"] = GJZ;
            TempData["startDate"] = startDate;
            TempData["endDate"] = endDate;
            return View();
        }

        public ActionResult XCFFCX2(int currentPage, int pageSize,string Salarystandardid = "", string GJZ = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            int rows = 0;
            List<SalaryGrantModel> list = isb.SalaryGrantFYW(currentPage, pageSize, out rows, Salarystandardid, GJZ, startDate, endDate);
            TempData["rows"] = rows;
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetRow2()
        {
           
            return Content(TempData["rows"].ToString());
        }
    }
    
  
    public class lei
    {
        public int sid { get; set; }
        public string mc { get; set; }
    }
}