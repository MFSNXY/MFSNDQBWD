using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IMechanismFirstBLL
    {

        int MechanismFirstAdd(MechanismFirstModel p);

        int MechanismFirstUpdate(MechanismFirstModel p);

        int MechanismFirstDelete(int id);

        MechanismFirstModel MechanismFirstBy(int id);

        List<MechanismFirstModel> MechanismFirstSelect();

        List<MechanismFirstModel> MechanismFirstFY(int currentPage, int pageSize, out int rows);
    }
}
