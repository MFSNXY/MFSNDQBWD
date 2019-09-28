using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IConfigPublicCharBLL
    {
 
        int ConfigPublicCharDelete(ConfigPublicCharModel ck);
        List<ConfigPublicCharModel> ConfigMajorKindSelect();
        List<ConfigPublicCharModel> ConfigMajorKindStudentBy(string lx);
    }
}
