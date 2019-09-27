using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using IBLL;
using IDAO;
using DAO;
using Model;

namespace BLL
{
    public class MechanismSecondBLL : IMechanismSecondBLL
    {
        IMechanismSecondDAO imd = IocCreate.CreateDao<IMechanismSecondDAO, MechanismSecondDAO>();

        public int MechanismSecondAdd(MechanismSecondModel p)
        {
            return imd.MechanismSecondAdd(p);
        }

        public MechanismSecondModel MechanismSecondBy(int id)
        {
            return imd.MechanismSecondBy(id);
        }

        public int MechanismSecondDelete(int id)
        {
            return imd.MechanismSecondDelete(id);
        }

        public List<MechanismSecondModel> MechanismSecondFY(int currentPage, int pageSize, out int rows)
        {
            return imd.MechanismSecondFY(currentPage, pageSize, out rows);
        }

        public List<MechanismSecondModel> MechanismSecondSelect()
        {
            return imd.MechanismSecondSelect();
        }

        public List<MechanismSecondModel> MechanismSecondSelectFirst(string firstId)
        {
            return imd.MechanismSecondSelectFirst(firstId);
        }

        public int MechanismSecondUpdate(MechanismSecondModel p)
        {
            return imd.MechanismSecondUpdate(p);
        }
    }
}
