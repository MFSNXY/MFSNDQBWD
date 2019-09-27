using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IMechanismThirdDAO
    {

        int MechanismThirdAdd(MechanismThirdModel p);

        int MechanismThirdUpdate(MechanismThirdModel p);

        int MechanismThirdDelete(int id);

        MechanismThirdModel MechanismThirdBy(int id);

        List<MechanismThirdModel> MechanismThirdSelect();
        
        List<MechanismThirdModel> MechanismThirdSelectFirst(string firstId);
        List<MechanismThirdModel> MechanismThirdSelectSecond(string secondId);

    }
}
