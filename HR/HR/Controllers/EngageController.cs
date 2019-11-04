using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using BLL;
using Newtonsoft.Json;
using Model;

namespace HR.Controllers
{
    public class EngageController : Controller
    {
        IMechanismThirdBLL imb = IocCreate.CreateBLL<IMechanismThirdBLL>("MechanismThirdBLL");

        IEngageBLL ieb = IocCreate.CreateBLL<IEngageBLL>("EngageBLL");

        IConfigMajorBLL icb = IocCreate.CreateBLL<IConfigMajorBLL>("ConfigMajorBLL");
        
        // GET: Engage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 职位发布登记
        /// </summary>
        /// <returns></returns>
        public ActionResult ToAddEngageRelease()
        {
            return View();
        }

        /// <summary>
        /// 按一级二级id获取三级机构
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult GetMTs(string fid,string sid)
        {
            return Content(JsonConvert.SerializeObject(imb.MechanismThirdSelectFS(fid, sid)));
        }

        /// <summary>
        /// 添加职位发布
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public ActionResult AddEngageRelease(EngageModel em)
        {
            em.ChangeTime = DateTime.Now;
            if (ieb.EngageAdd(em)>0)
            {
                return Content("<script>alert('添加成功');location='../Engage/ToAddEngageRelease';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');location='../Engage/ToAddEngageRelease';</script>");
            }
        }

        /// <summary>
        /// 职位发布变更
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectUpdate()
        {
            return View();
        }
        /// <summary>
        /// 获取职位发布列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult GetEngages(int currentPage,int pageSize)
        {
            int rows = 0;
            return Content(JsonConvert.SerializeObject(ieb.EngageFY(currentPage, pageSize, out rows)));
        }
        
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRow()
        {
            int rows = 0;
            ieb.EngageFY(1, 4, out rows);
            return Content(rows+"");
        }

        /// <summary>
        /// 职位发布删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            return Content(ieb.EngageDelete(id).ToString());
        }

        /// <summary>
        /// 变更页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ToUpdate(int id)
        {
            return View(ieb.EngageBy(id));
        }

        /// <summary>
        /// 职位发布修改
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public ActionResult Update(EngageModel em)
        {
            if (ieb.EngageUpdate(em) > 0)
            {
                return Content("<script>alert('修改成功!');location='/Engage/SelectUpdate';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败!');</script>");
            }
        }

        /// <summary>
        /// 职位发布查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectFB()
        {
            return View();
        }

        /// <summary>
        /// 获取职称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMs(string id)
        {
            return Content(JsonConvert.SerializeObject(icb.ConfigMajorSelectMKId(id)));
        }


    }
}