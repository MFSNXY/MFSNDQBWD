    using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IocContainer
{
    public class IocCreate
    {

        public static TIDAO CreateDao<TIDAO, TDAO>() where TDAO : TIDAO
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<TIDAO, TDAO>();
            return ioc.Resolve<TIDAO>();
        }

        public static TIBLL CreateBLL<TIBLL>(string name)
        {
            UnityContainer ioc = new UnityContainer();
            ExeConfigurationFileMap ef = new ExeConfigurationFileMap();
            ef.ExeConfigFilename = @"C:\Users\Szhbaba\Source\Repos\MFSNDQBWD\HR\HR\Unity.config";
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);
            UnityConfigurationSection cs = cf.GetSection("unity") as UnityConfigurationSection;
            ioc.LoadConfiguration(cs, "containerTwo");
            return ioc.Resolve<TIBLL>(name);
        }

    }
}
