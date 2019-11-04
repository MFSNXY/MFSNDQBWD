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
        IHumanFileBLL ihb = IocContainer.IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");
        ISalaryGrantdetailsBLL igb = IocContainer.IocCreate.CreateBLL<ISalaryGrantdetailsBLL>("SalaryGrantdetailsBLL");
        ISalaryStandardDetailsBLL ilb = IocContainer.IocCreate.CreateBLL<ISalaryStandardDetailsBLL>("SalaryStandardDetailsBLL");
        /// <summary>
        /// 加载薪酬发放登记页面
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 一级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult YJJG()
        {
            return View();
        }
        /// <summary>
        /// 按一级机构查询
        /// </summary>
        /// <returns></returns>
        public ActionResult YJJG2()
        {
            List<SalaryGrantModel> list = ihb.HumanFileSelectYJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 二级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult EJJG()
        {
            return View();
        }
        /// <summary>
        /// 按二级机构查询
        /// </summary>
        /// <returns></returns>
        public ActionResult EJJG2()
        {
            List<SalaryGrantModel> list = list = ihb.HumanFileSelectEJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 三级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult SJJG()
        {
            return View();
        }
        /// <summary>
        /// 按三级机构查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SJJG2()
        {
            List<SalaryGrantModel> list = list = ihb.HumanFileSelectSJ();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 按查询机构跳转
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
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
            else if (i ==3)
            {
                return RedirectToAction("SJJG");
            }
            else
            {
                return View();
            }

        }

        /// <summary>
        /// 薪酬发放登记
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sid"></param>
        /// <param name="Humanamount"></param>
        /// <param name="Salarypaidsum"></param>
        /// <param name="Salarystandardsum"></param>
        /// <param name="Firstkindid"></param>
        /// <param name="Secondkindid"></param>
        /// <param name="Thirdkindid"></param>
        /// <param name="Thirdkindname"></param>
        /// <param name="Firstkindname"></param>
        /// <param name="Secondkindname"></param>
        /// <returns></returns>
        public ActionResult Commit(string id,int sid,int Humanamount,decimal Salarypaidsum,decimal Salarystandardsum, string Firstkindid, string Secondkindid,string Thirdkindid,string Thirdkindname,string Firstkindname,string Secondkindname)
        {
            SalaryGrantModel sg = new SalaryGrantModel();
            sg.Salarygrantid = id;
            sg.Firstkindid = Firstkindid;
            sg.Firstkindname = Firstkindname;
            sg.Secondkindid = Secondkindid;
            sg.Secondkindname = Secondkindname;
            sg.Thirdkindid = Thirdkindid;
            sg.Thirdkindname = Thirdkindname;
            sg.Humanamount = Humanamount;
            sg.Salarypaidsum = Salarystandardsum;
            sg.Salarystandardsum = Salarypaidsum;
            int pd = isb.SelectPD(Firstkindid, Secondkindid, Thirdkindid);
            if (pd>0)
            {

            }
            else
            {
                int i = isb.SalaryGrantAdd(sg);
            }
            
            

            ViewBag.Humanamount = Humanamount;
            ViewBag.Firstkindid = Firstkindid;
            ViewBag.Secondkindid = Secondkindid;
            ViewBag.Thirdkindid = Thirdkindid;
            ViewBag.id = id;
            ViewBag.sid = sid;
            return View();
        }

        /// <summary>
        /// 薪酬发放复核明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult Check(string id, int sid)
        {
            ViewBag.id = id;
            ViewBag.sid = sid;
            return View();
        }

        /// <summary>
        /// 薪酬发放复核
        /// </summary>
        /// <param name="Salarygrantid"></param>
        /// <param name="Id"></param>
        /// <param name="Firstkindid"></param>
        /// <param name="Secondkindid"></param>
        /// <param name="Thirdkindid"></param>
        /// <returns></returns>
        public ActionResult Commit2(string Salarygrantid,int Id, string Firstkindid, string Secondkindid,string Thirdkindid)
        {
            
            string sgid = Salarygrantid;
            int sid1=Id;
           
            if (Firstkindid != null &&Secondkindid=="")
            {
                List<XCFFSTModel> list = ihb.HumanFileSelectYJXQ(Firstkindid);
                return Content(JsonConvert.SerializeObject(list));
            }
            else if (Firstkindid != null && Secondkindid != ""&& Thirdkindid=="")
            {
                List<XCFFST2Model> list = ihb.HumanFileSelectEJXQ(Secondkindid);
                return Content(JsonConvert.SerializeObject(list));
            }
            else
            {
                List<XCFFST3Model> list = ihb.HumanFileSelectSJXQ(Thirdkindid);
                return Content(JsonConvert.SerializeObject(list));
            }
            
        }

        /// <summary>
        /// 获取薪酬发放明细集合
        /// </summary>
        /// <param name="Salarygrantid"></param>
        /// <param name="Id"></param>
        /// <param name="Firstkindid"></param>
        /// <param name="Secondkindid"></param>
        /// <returns></returns>
        public ActionResult FuheCx(string Salarygrantid, int Id, string Firstkindid, string Secondkindid)
        {

            string sgid = Salarygrantid;
            int sid1 = Id;
            List<SalaryGrantdetailsModel> list = igb.SalaryGrantdetailsSelectID(sgid);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 获取薪酬发放明细
        /// </summary>
        /// <param name="SalaryStandardId"></param>
        /// <returns></returns>
        public ActionResult Commit3(string SalaryStandardId)
        {

            string sid = SalaryStandardId;
            List<SalaryStandardDetailsModel> list = ilb.SalaryGrantdetailsSelectGZXQ(sid);
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 薪酬发放登记成功
        /// </summary>
        /// <returns></returns>
        public ActionResult registersuccess()
        {
            return View();
        }

        /// <summary>
        /// 薪酬发放复核成功
        /// </summary>
        /// <returns></returns>
        public ActionResult ckeckstersuccess()
        {
            return View();
        }
        /// <summary>
        /// 薪酬发放登记点击提交的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult xg()
        {
            SalaryGrantModel sg = new SalaryGrantModel();
            sg.Firstkindid = Request["Fid"];
            sg.Secondkindid= Request["Seid"];
            sg.Thirdkindid = Request["Thid"];
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
                sm.Salarygrantid = item["SalaryId"].ToString();
                sm.Humanid = item["HumanId"].ToString();
                sm.Humanname = item["HumanName"].ToString();
                object ass = item["Bounssum"];
                sm.Bounssum = item["Bounssum"]==null|| item["Bounssum"] == ""? sm.Bounssum: Convert.ToDecimal(item["Bounssum"]);
                sm.Salesum = item["Salesum"] == null || item["Salesum"] == "" ? sm.Salesum : Convert.ToDecimal(item["Salesum"]);
                sm.Deductsum = item["Deductsum"] == null || item["Deductsum"] == "" ? sm.Deductsum : Convert.ToDecimal(item["Deductsum"]);
                sm.Salarypaidsum = item["Salarypaidsum"] == null || item["Salarypaidsum"] == "" ? sm.Salarypaidsum : Convert.ToDecimal(item["Salarypaidsum"]);
                HumanFileModel hf = new HumanFileModel();
                hf.Id = Convert.ToInt32(item["Id"]);
                ihb.HumanFileUpdate1(hf);
                //判断薪酬发放表是否添加过这条数据
                if (isb.SelectPDSID(sm.Salarygrantid,sm.Humanid)>0)
                {
                    r2++;
                }
                else
                {
                    if (igb.SalaryGrantdetailsAdd(sm) > 0)
                    {
                        r2++;
                    }
                }
                

            }
            string flag = "false";
            if (r1 > 0 && r2 == sdm.Count)
            {
                flag = "true";
            }
            return Content(flag);
        }

        /// <summary>
        /// 薪酬发放复核点击提交的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult xg2()
        {
            SalaryGrantModel sg = new SalaryGrantModel();
            sg.Id = Convert.ToInt32(Request["Id"]);
            sg.Register = Request["Register"];
            sg.Registtime = DateTime.Now;
            sg.Checker = Request["Checker"];
            sg.Checktime = Convert.ToDateTime(Request["Checktime"]);
            sg.Checkstatus =3;
            int r1 = isb.SalaryGrantUpdate2(sg);

            string arry = Request["arry"];
            List<Dictionary<string, object>> sdm = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(arry);
            int r2 = 0;
            foreach (var item in sdm)
            {
                SalaryGrantdetailsModel sm = new SalaryGrantdetailsModel();
                sm.Id = int.Parse(item["Id"].ToString());
                sm.Bounssum = item["Bounssum"] == null || item["Bounssum"] == "" ? sm.Bounssum : Convert.ToDecimal(item["Bounssum"]);
                sm.Salesum = item["Salesum"] == null || item["Salesum"] == "" ? sm.Salesum : Convert.ToDecimal(item["Salesum"]);
                sm.Deductsum = item["Deductsum"] == null || item["Deductsum"] == "" ? sm.Deductsum : Convert.ToDecimal(item["Deductsum"]);
                sm.Salarypaidsum = item["Salarypaidsum"] == null || item["Salarypaidsum"] == "" ? sm.Salarypaidsum : Convert.ToDecimal(item["Salarypaidsum"]);
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

        public ActionResult XCFFCX(string Salarystandardid = "", string GJZ="", string year = null, string months = null)
        {
            TempData["Salarystandardid"] = Salarystandardid;
            TempData["GJZ"] = GJZ;
            TempData["year"] = year;
            TempData["months"] = months;
            return View();
        }

        public ActionResult XCFFCX2(int currentPage, int pageSize,string Salarystandardid = "", string GJZ = "", string year = null, string months = null)
        {
            int rows = 0;
            List<SalaryGrantModel> list = isb.SalaryGrantFYW(currentPage, pageSize, out rows, Salarystandardid, GJZ, year, months);
            TempData["rows"] = rows;
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetRow2()
        {
           
            return Content(TempData["rows"].ToString());
        }

        public ActionResult Query(string Salarygrantid)
        {
            TempData["Salarygrantid"] = Salarygrantid;
            return View();
        }

        public ActionResult Query2(string Salarygrantid)
        {
            string sgid = Salarygrantid;
            List<SalaryGrantdetailsModel> list = igb.SalaryGrantdetailsSelectID(sgid);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 薪酬发放复核的工资详情的方法
        /// </summary>
        /// <param name="Humanid"></param>
        /// <returns></returns>
        public ActionResult QueryHid(string Humanid)
        {
            string hid = Humanid;
            string hid2 = ihb.XCFFSTHID(hid);
            List<SalaryStandardDetailsModel> list = ilb.SalaryGrantdetailsSelectGZXQ(hid2);
            return Content(JsonConvert.SerializeObject(list));
        }
    }
    
              
    public class lei
    {
        public int sid { get; set; }
        public string mc { get; set; }
    }
}