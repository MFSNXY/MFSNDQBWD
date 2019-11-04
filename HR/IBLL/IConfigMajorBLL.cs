using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IConfigMajorBLL
    {
        int ConfigMajorAdd(ConfigMajorModel ck);
        int ConfigMajorUpdate(ConfigMajorModel ck);
        int ConfigMajorDelete(ConfigMajorModel ck);
        List<ConfigMajorModel> ConfigMajorSelect();
        List<ConfigMajorModel> ConfigMajorSelectBy(int id);
        List<ConfigMajorModel> ConfigMajorSelectMKId(string id);
        // string fff(string id);

        string GetBH();
    }
}
