using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface IConfigPublicCharDAO
    {
        
        int ConfigPublicCharDelete(ConfigPublicCharModel ck);
        List<ConfigPublicCharModel> ConfigMajorKindSelect();
        List<ConfigPublicCharModel> ConfigMajorKindStudentBy(string lx);
    }
}
