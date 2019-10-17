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
    public class ConfigMajorKindBLL: IConfigMajorKindBLL
    {
        IConfigMajorKindDAO icd = IocContainer.IocCreate.CreateDao<IConfigMajorKindDAO, ConfigMajorKindDAO>();

        public int ConfigMajorKindAdd(ConfigMajorKindModel ckm)
        {
            return icd.ConfigMajorKindAdd(ckm);
        }

        public List<ConfigMajorKindModel> ConfigMajorKindBy(int id)
        {
            return icd.ConfigMajorKindStudentBy(id);
        }

        public int ConfigMajorKindDelete(ConfigMajorKindModel ckm)
        {
            return icd.ConfigMajorKindDelete(ckm);
        }

        public List<ConfigMajorKindModel> ConfigMajorKindSelect()
        {
            return icd.ConfigMajorKindSelect();
        }

        public int ConfigMajorKindUpdate(ConfigMajorKindModel ckm)
        {
            return icd.ConfigMajorKindUpdate(ckm);
        }

        public string fff(string id)
        {
            return icd.fff(id);
        }
    }
}
