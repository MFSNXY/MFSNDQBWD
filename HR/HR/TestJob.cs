using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBLL;
using Quartz;

namespace HR
{
    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {

            //更新状态（人力资源档案表的状态）归0
           
            IHumanFileBLL ihb = IocContainer.IocCreate.CreateBLL<IHumanFileBLL>("HumanFileBLL");
            ihb.HumanFileUpdateGL();

        }
    }
}           