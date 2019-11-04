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
    public class ConfigMajorBLL : IConfigMajorBLL
    {
        IConfigMajorDAO icd = IocContainer.IocCreate.CreateDao<IConfigMajorDAO, ConfigMajorDAO>();
        public int ConfigMajorAdd(ConfigMajorModel ck)
        {
            return icd.ConfigMajorAdd(ck);
        }

        public int ConfigMajorDelete(ConfigMajorModel ck)
        {
            return icd.ConfigMajorDelete(ck);
        }

        public List<ConfigMajorModel> ConfigMajorSelect()
        {
            return icd.ConfigMajorSelect();
        }

        public List<ConfigMajorModel> ConfigMajorSelectBy(int id)
        {
            return icd.ConfigMajorSelectBy(id);
        }

        public List<ConfigMajorModel> ConfigMajorSelectMKId(string id)
        {
            return icd.ConfigMajorSelectMKId(id);
        }

        public int ConfigMajorUpdate(ConfigMajorModel ck)
        {
            return icd.ConfigMajorUpdate(ck);
        }

        public string GetBH()
        {
            return icd.GetBH();
        }
    }
}
