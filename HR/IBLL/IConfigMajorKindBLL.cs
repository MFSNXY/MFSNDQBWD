using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IConfigMajorKindBLL
    {
        int ConfigMajorKindAdd(ConfigMajorKindModel ckm);
        int ConfigMajorKindUpdate(ConfigMajorKindModel ckm);
        int ConfigMajorKindDelete(ConfigMajorKindModel ckm);
        List<ConfigMajorKindModel> ConfigMajorKindSelect();
        List<ConfigMajorKindModel> ConfigMajorKindBy(int id);
        string fff(string id);
    }
}
