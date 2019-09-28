using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class ConfigPublicCharBLL : IConfigPublicCharBLL
    {
        IConfigPublicCharDAO icd = IocContainer.IocCreate.CreateDao<IConfigPublicCharDAO, ConfigPublicCharDAO>();

        public List<ConfigPublicCharModel> ConfigMajorKindSelect()
        {
            return icd.ConfigMajorKindSelect();
        }

        public List<ConfigPublicCharModel> ConfigMajorKindStudentBy(string lx)
        {
            return icd.ConfigMajorKindStudentBy(lx);
        }

        public int ConfigPublicCharDelete(ConfigPublicCharModel ck)
        {
            return icd.ConfigPublicCharDelete(ck);
        }
    }
}
