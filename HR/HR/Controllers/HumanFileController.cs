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
                return Content("<script>alert('登记成功!');location='/HumanFile/HumanFilePicture';</script>");
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

        public ActionResult HumanFileSCPicture(HttpPostedFileBase file)
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
                return Content("1");
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

        public ActionResult HumanFileCheckUpdate(HumanFileModel hf)
        {
            hf.CheckStatus = 1;
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
            HumanFileModel hf = new HumanFileModel();
            return View();
        }

    }
}