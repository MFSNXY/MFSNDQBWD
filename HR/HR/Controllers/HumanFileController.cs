using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using BLL;
using Model;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace HR.Controllers
{
    public class HumanFileController : Controller
    {
        IConfigPublicCharBLL icp = IocCreate.CreateBLL<IConfigPublicCharBLL>("ConfigPublicCharBLL");

        IHumanFileBLL ihf = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");

        // GET: HumanFile
        public ActionResult HumanFileRegister()
        {
            return View();
        }

        public ActionResult GetCPC()
        {
            return Content(JsonConvert.SerializeObject(icp.ConfigMajorKindSelect()));
        }

        public ActionResult Register(HumanFileModel hf)
        {
            hf.HumanId = "HF" + DateTime.Now.ToString("yyMMddssfff") + new Random().Next(100, 999);
            if (ihf.HumanFileAdd(hf) > 0)
            {
                TempData["hfid"] = hf.HumanId;
                return Content("<script>alert('登记成功!');location='/HumanFile/HumanFilePicture?gn=1';</script>");
            }
            else
            {
                return Content("<script>alert('登记失败!');</script>");
            }
        }

        public ActionResult HumanFilePicture()
        {
            return View();
        }

        public ActionResult HumanFileSCPicture(HttpPostedFileBase file,int gn)
        {
            byte[] bts = MD5.Create().ComputeHash(file.InputStream);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bts)
            {
                sb.Append(b.ToString("X2"));
            }
            string name = sb.ToString();
            string ext = Path.GetExtension(file.FileName);
            string path = Server.MapPath("~/HumanFileImage/" + DateTime.Now.ToString("yyyy/MM/dd")) + "/" + name + ext;
            new FileInfo(path).Directory.Create();
            file.SaveAs(path);
            if (ihf.HumanFileSetPic((string)TempData["hfid"], path) > 0)
            {
                return Content(gn+"");
            }
            else
            {
                return Content("0");
            }
        }

        public ActionResult HumanFileCheckList()
        {
            return View();
        }

        public ActionResult GetHumanFileCheckList(int currentPage, int pageSize)
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileCheckList(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));

        }

        public ActionResult HumanFileCheck(int id)
        {
            return View(ihf.HumanFileBy(id));
        }

        public ActionResult HumanFileCheckUpdate(HumanFileModel e)
        {
            HumanFileModel hf = ihf.HumanFileBy(e.Id);
            hf.CheckStatus = 1;
            hf.Checker = e.Checker;
            hf.CheckTime = e.CheckTime;
            if (ihf.HumanFileUpdate(hf) > 0)
            {
                return Content("<script>alert('复核成功!');location='/HumanFile/HumanFileCheckList';</script>");
            }
            else
            {
                return Content("<script>alert('复核失败!');</script>");
            }
        }

        public ActionResult HumanFileQueryLocate()
        {
            return View();
        }

        public ActionResult HumanFileQueryKeywords()
        {
            return View();
        }
        public ActionResult HumanFileQueryListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }


        public ActionResult HumanFileQueryList(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            TempData["FirstMid"] = FirstMid;
            TempData["SecondMid"] = SecondMid;
            TempData["ThirdMid"] = ThirdMid;
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = gjz;
            TempData["StartTime"] = startTime;
            TempData["EndTime"] = endTime;
            return View();
        }

        public ActionResult HumanFileGetHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileQueryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult HumanFileChangeLocate()
        {
            return View();
        }

        public ActionResult HumanFileChangeKeywords()
        {
            return View();
        }
        public ActionResult HumanFileChangeList(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            TempData["FirstMid"] = FirstMid;
            TempData["SecondMid"] = SecondMid;
            TempData["ThirdMid"] = ThirdMid;
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = gjz;
            TempData["StartTime"] = startTime;
            TempData["EndTime"] = endTime;
            return View();
        }

        public ActionResult HumanFileChangeGetHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileQueryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }
    

        public ActionResult HumanFileChangeListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }

        public ActionResult HumanFileChangeUpdate(HumanFileModel hf)
        {
            if (ihf.HumanFileUpdate(hf) > 0)
            {
                TempData["hfid"] = hf.HumanId;
                return Content("<script>alert('修改成功!');location='/HumanFile/HumanFilePicture?gn=2';</script>");
            }
            else
            {
                return Content("<script>alert('修改成功!');</script>");
            }
        }

        public ActionResult HumanFileDeleteLocate()
        {
            return View();
        }

        public ActionResult HumanFileDeleteKeywords()
        {
            return View();
        }
        public ActionResult HumanFileDeleteListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }


        public ActionResult HumanFileDeleteList(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            TempData["FirstMid"] = FirstMid;
            TempData["SecondMid"] = SecondMid;
            TempData["ThirdMid"] = ThirdMid;
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = gjz;
            TempData["StartTime"] = startTime;
            TempData["EndTime"] = endTime;
            return View();
        }

        public ActionResult HumanFileGetDeleteHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileDeleteList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult HumanFileDelete(int id)
        {
            HumanFileModel hf = ihf.HumanFileBy(id);
            hf.HumanFileStatus = true;
            if (ihf.HumanFileUpdate(hf)>0)
            {
                return Content("<script>alert('删除成功!');location='/HumanFile/HumanFileDeleteLocate';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败!');</script>");
            }
        }

        public ActionResult HumanFileRecoveryLocate()
        {
            return View();
        }

        public ActionResult HumanFileRecoveryKeywords()
        {
            return View();
        }
        public ActionResult HumanFileRecoveryListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }


        public ActionResult HumanFileRecoveryList(string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            TempData["FirstMid"] = FirstMid;
            TempData["SecondMid"] = SecondMid;
            TempData["ThirdMid"] = ThirdMid;
            TempData["HumanMajorKindId"] = HumanMajorKindId;
            TempData["HumanMajorId"] = HumanMajorId;
            TempData["GJZ"] = gjz;
            TempData["StartTime"] = startTime;
            TempData["EndTime"] = endTime;
            return View();
        }

        public ActionResult HumanFileGetRecoveryHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileRecoveryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult HumanFileRecovery(int id)
        {
            HumanFileModel hf = ihf.HumanFileBy(id);
            hf.HumanFileStatus = false;
            if (ihf.HumanFileUpdate(hf) > 0)
            {
                return Content("<script>alert('恢复成功!');location='/HumanFile/HumanFileRecoveryLocate';</script>");
            }
            else
            {
                return Content("<script>alert('恢复失败!');</script>");
            }
        }

        public ActionResult HumanFileDeleteForeverList()
        {
            return View();
        }

        public ActionResult HumanFileGetDeleteForeverHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileRecoveryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        public ActionResult HumanFileDeleteForever(int id)
        {
            if (ihf.HumanFileDelete(id) > 0)
            {
                return Content("<script>alert('永久删除成功!');location='/HumanFile/HumanFileDeleteForeverList';</script>");
            }
            else
            {
                return Content("<script>alert('永久删除失败!');</script>");
            }
        }

    }
}