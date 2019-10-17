using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface IConfigMajorKindDAO
    {
        int ConfigMajorKindAdd(ConfigMajorKindModel ck);
        int ConfigMajorKindUpdate(ConfigMajorKindModel ck);
        int ConfigMajorKindDelete(ConfigMajorKindModel ck);
        List<ConfigMajorKindModel> ConfigMajorKindSelect();
        List<ConfigMajorKindModel> ConfigMajorKindStudentBy(int id);
        string fff(string id);
    }
}
