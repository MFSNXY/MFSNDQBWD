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
        //IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");
        public IEngageResumeBLL ierb { get; set; }
        //IConfigPublicCharBLL icp = IocCreate.CreateBLL<IConfigPublicCharBLL>("ConfigPublicCharBLL");
        public IConfigPublicCharBLL icp { get; set; }
        //IHumanFileBLL ihf = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");
        public IHumanFileBLL ihf { get; set; }
        // GET: HumanFile

            /// <summary>
            /// 人力资源登记页面
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public ActionResult HumanFileRegister(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            return View(er);
        }

        /// <summary>
        /// 人力资源可登记列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileRegisterList()
        {
            return View();
        }

        /// <summary>
        /// 获取可登记简历
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult HumanFileGetRegisterList(int currentPage, int pageSize)
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileFY(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));

        }

        /// <summary>
        /// 获取公共属性
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCPC()
        {
            return Content(JsonConvert.SerializeObject(icp.ConfigMajorKindSelect()));
        }

        /// <summary>
        /// 人力资源登记
        /// </summary>
        /// <param name="hf"></param>
        /// <param name="ERid"></param>
        /// <returns></returns>
        public ActionResult Register(HumanFileModel hf,int ERid)
        {
            hf.HumanId = "HF" + DateTime.Now.ToString("yyMMddssfff") + new Random().Next(100, 999);
            hf.Zhuangtai = 0;
            #region 移动图片
            string name = hf.HumanPicture.Substring(hf.HumanPicture.LastIndexOf('/'));
            string path = Server.MapPath("~/HumanFileImage/" + DateTime.Now.ToString("yyyy/MM/dd")) + "/" + name;
            new FileInfo(path).Directory.Create();
            FileInfo file1 = new FileInfo(hf.HumanPicture);
            file1.CopyTo(path);
            hf.HumanPicture = path;
            #endregion
            if (ihf.HumanFileAdd(hf) > 0)
            {
                EngageResumeModel er = ierb.EngageResumeSelectBy(ERid);
                er.InterviewStatus = 5;
                ierb.EngageResumeUpdate(er);
                Session["hfid"] = hf.HumanId;
                return Content("<script>alert('登记成功!');location='/HumanFile/HumanFilePicture?gn=1';</script>");
            }
            else
            {
                return Content("<script>alert('登记失败!');</script>");
            }
        }

        /// <summary>
        /// 人力资源上传图片页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFilePicture()
        {
            return View();
        }

        /// <summary>
        /// 人力资源上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <param name="gn"></param>
        /// <returns></returns>
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
            if (ihf.HumanFileSetPic((string)Session["hfid"], path) > 0)
            {
                return Content(gn+"");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 人力资源待复核列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileCheckList()
        {
            return View();
        }
        /// <summary>
        /// 获取人力资源待复核列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 人力资源复核明细页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HumanFileCheck(int id)
        {
            HumanFileModel hf = ihf.HumanFileBy(id);
            return View(hf);
        }

        /// <summary>
        /// 人力资源复核
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 人力资源查询搜索页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileQueryLocate()
        {
            return View();
        }

        /// <summary>
        /// 人力资源关键字搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileQueryKeywords()
        {
            return View();
        }
        
        /// <summary>
        /// 人力资源查询明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HumanFileQueryListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }

        /// <summary>
        /// 人力资源查询列表页面
        /// </summary>
        /// <param name="FirstMid"></param>
        /// <param name="SecondMid"></param>
        /// <param name="ThirdMid"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="gjz"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取人力资源查询列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="FirstMid"></param>
        /// <param name="SecondMid"></param>
        /// <param name="ThirdMid"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="gjz"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 人力资源变更条件搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileChangeLocate()
        {
            return View();
        }

        /// <summary>
        /// 人力资源变更关键字搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult HumanFileChangeKeywords()
        {
            return View();
        }

        /// <summary>
        /// 人力资源变更列表页面
        /// </summary>
        /// <param name="FirstMid"></param>
        /// <param name="SecondMid"></param>
        /// <param name="ThirdMid"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="gjz"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取人力资源变更列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="FirstMid"></param>
        /// <param name="SecondMid"></param>
        /// <param name="ThirdMid"></param>
        /// <param name="HumanMajorKindId"></param>
        /// <param name="HumanMajorId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="gjz"></param>
        /// <returns></returns>
        public ActionResult HumanFileChangeGetHuman(int currentPage, int pageSize, string FirstMid = "", string SecondMid = "", string ThirdMid = "", string HumanMajorKindId = "", string HumanMajorId = "", DateTime? startTime = null, DateTime? endTime = null, string gjz = "")
        {
            int rows = 0;
            List<HumanFileModel> list = ihf.HumanFileChangList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }
    
        /// <summary>
        /// 人力资源变更明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HumanFileChangeListInformation(int id)
        {
            return View(ihf.HumanFileBy(id));
        }

        /// <summary>
        /// 人力资源变更
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        public ActionResult HumanFileChangeUpdate(HumanFileModel hf)
        {
            if (ihf.HumanFileUpdate(hf) > 0)
            {
                Session["hfid"] = hf.HumanId;
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

        public ActionResult HumanFileFile()
        {
            return View();
        }

        public ActionResult HumanFileFileSC(HttpPostedFileBase accFile,int gn)
        {
            byte[] bts = MD5.Create().ComputeHash(accFile.InputStream);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bts)
            {
                sb.Append(b.ToString("X2"));
            }
            string name = sb.ToString();
            string ext = Path.GetExtension(accFile.FileName);
            string path = Server.MapPath("~/HumanFileFile/" + DateTime.Now.ToString("yyyy/MM/dd")) + "/" + name + ext;
            new FileInfo(path).Directory.Create();
            accFile.SaveAs(path);
            if (ihf.HumanFileSetAttachmentName((string)Session["hfid"], path) > 0)
            {
                if (gn == 1)
                {
                    return Content("<script>alert('上传成功!'); window.location.href='/HumanFile/HumanFileRegisterList'</script>");
                }
                else
                {
                    return Content("<script>alert('上传成功!'); window.location.href='/HumanFile/HumanFileChangeLocate'</script>");
                }
            }
            else
            {
                return Content("<script>alert('上传失败!'); window.location.href='/HumanFile/HumanFileFile?gn="+gn+"'</script>");
            }
        }

    }
}