using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using IDAO;
using DAO;
using Model;
using IBLL;

namespace BLL
{
    public class MechanismFirstBLL : IMechanismFirstBLL
    {
        IMechanismFirstDAO imd = IocCreate.CreateDao<IMechanismFirstDAO, MechanismFirstDAO>();

        public int MechanismFirstAdd(MechanismFirstModel p)
        {
            return imd.MechanismFirstAdd(p);
        }

        public MechanismFirstModel MechanismFirstBy(int id)
        {
            return imd.MechanismFirstBy(id);
        }

        public int MechanismFirstDelete(int id)
        {
            return imd.MechanismFirstDelete(id);
        }

        public List<MechanismFirstModel> MechanismFirstFY(int currentPage, int pageSize, out int rows)
        {
            return imd.MechanismFirstFY(currentPage, pageSize, out rows);
        }

        public List<MechanismFirstModel> MechanismFirstSelect()
        {
            return imd.MechanismFirstSelect();
        }

        public int MechanismFirstUpdate(MechanismFirstModel p)
        {
            return imd.MechanismFirstUpdate(p);
        }
    }
}
