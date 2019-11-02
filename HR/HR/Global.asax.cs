using Autofac;
using Autofac.Integration.Mvc;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            //创建一个工作对象
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            int day = int.Parse(ConfigurationManager.AppSettings["day"]);
            int huor = int.Parse(ConfigurationManager.AppSettings["hour"]);
            int mi = int.Parse(ConfigurationManager.AppSettings["mi"]);
            //创建触发条件
            IMutableTrigger triggerBossReport = CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(day, huor, mi).Build();
            //设置触发条件的键名
            triggerBossReport.Key = new TriggerKey("test");
            //给计划按触发条件执行工作
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            //计划启动
            sched.Start();

           // BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerBuilder cb = new ContainerBuilder();
            //把当前程序集中的 Controller 都注册
            cb.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            //注册实现IUserBLL的实现类
            //  cb.RegisterType<UserBLL>().As<IUserBLL>();
            Assembly ass = Assembly.Load("BLL");
            cb.RegisterAssemblyTypes(ass).AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
            IContainer ioc = cb.Build();

            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。
            DependencyResolver.SetResolver(new AutofacDependencyResolver(ioc));

        }
    }
}
