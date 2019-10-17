using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IMechanismSecondBLL
    {
        int MechanismSecondAdd(MechanismSecondModel p);

        int MechanismSecondUpdate(MechanismSecondModel p);

        int MechanismSecondDelete(int id);

        MechanismSecondModel MechanismSecondBy(int id);

        List<MechanismSecondModel> MechanismSecondSelect();

        List<MechanismSecondModel> MechanismSecondFY(int currentPage, int pageSize, out int rows);

        List<MechanismSecondModel> MechanismSecondSelectFirst(string firstId);
    }
}
