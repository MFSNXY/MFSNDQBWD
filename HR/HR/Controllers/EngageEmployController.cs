﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IBLL;
using BLL;
using Newtonsoft.Json;
using Model;
using System.Net.Mail;
using System.Net;

namespace HR.Controllers
{
    public class EngageEmployController : Controller
    {
        IHumanFileBLL ihf = IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");

        IEngageBLL ieb = IocCreate.CreateBLL<IEngageBLL>("EngageBLL");

        IEngageResumeBLL ierb = IocCreate.CreateBLL<IEngageResumeBLL>("EngageResumeBLL");

        IEngageInterviewBLL ieib = IocCreate.CreateBLL<IEngageInterviewBLL>("EngageInterviewBLL");
        // GET: EngageEmploy
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取待申请的简历
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult GetEngageEmployLYSQ(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYSQ(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        /// <summary>
        /// 简历录用申请明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GoEngageEmploySQ(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

        /// <summary>
        /// 简历录用申请
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PassCheckComment"></param>
        /// <returns></returns>
        public ActionResult EngageEmploySQ(int id,string PassCheckComment)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            er.PassCheckComment = PassCheckComment;
            if (ierb.EngageResumeUpdate(er) > 0)
            {
                return Content("<script>alert('提交成功!');location='/EngageEmploy/Index';</script>");
            }
            else
            {
                return Content("<script>alert('提交失败!');</script>");
            }
        }

        /// <summary>
        /// 简历录用审批
        /// </summary>
        /// <returns></returns>
        public ActionResult LYSP()
        {
            return View();
        }

        /// <summary>
        /// 获取待审批的简历
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult GetEngageEmployLYSP(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYSP(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        /// <summary>
        /// 简历审批明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GoEngageEmploySP(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

        /// <summary>
        /// 简历审批
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PassPassComment"></param>
        /// <returns></returns>
        public ActionResult EngageEmploySP(int id, string PassPassComment)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            er.PassPassComment = PassPassComment;
            if (ierb.EngageResumeUpdate(er) > 0)
            {
            //修改职位发布表的人数(-1)
                if (er.EngageId > 0) {
                    EngageModel em = ieb.EngageBy(er.EngageId);
                    if (em != null)
                    {
                        if (em.ManCount > 0) {
                            em.ManCount--;
                            ieb.EngageUpdate(em);
                        }
                    }
                }
                if (er.HumanEmail != null && er.HumanEmail != "")
                {
                    MailMessage mail = new MailMessage();
                    //发件人邮件地址
                    mail.From = new MailAddress("XY13308469744@163.com");
                    //mail.From = new MailAddress("jw_112255@163.com");
                    //接收S人的邮件地址
                    mail.To.Add(new MailAddress(er.HumanEmail));
                    //mail.To.Add(new MailAddress("yisen.jiang@qq.com"));
                    //主题
                    mail.Subject = string.Format("恭喜{0}入职", er.HumanName);
                    mail.Body = string.Format("{0}，你通过了我们公司的面试。快点来入职。", er.HumanName);

                    //创建smtp协议对象
                    SmtpClient sc = new SmtpClient("smtp.163.com")
                    {
                        UseDefaultCredentials = true,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    }; ;
                    //邮件服务发送的凭证
                    sc.Credentials = new NetworkCredential("XY13308469744@163.com", "123456qq");
                    sc.Send(mail);
                }
                return Content("<script>alert('提交成功!');location='/EngageEmploy/LYSP';</script>");
            }
            else
            {
                return Content("<script>alert('提交失败!');</script>");
            }
        }

        /// <summary>
        /// 录用查询
        /// </summary>
        /// <returns></returns>
        public ActionResult LYCX()
        {
            return View();
        }

        /// <summary>
        /// 获取录用查询列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult GetEngageEmployLYCX(int currentPage, int pageSize)
        {
            int rows = 0;
            List<EngageResumeModel> list = ierb.EngageResumeSelectLYCX(currentPage, pageSize, out rows);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"list",list },
                {"rows",rows }
            };
            return Content(JsonConvert.SerializeObject(dic));
        }

        /// <summary>
        /// 录用查询明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EngageEmployLYCX(int id)
        {
            EngageResumeModel er = ierb.EngageResumeSelectBy(id);
            EngageInterviewModel ei = ieib.EngageInterviewSelectResumeId(id);
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"er",er }, {"ei",ei }
            };
            return View(dic);
        }

    }
}