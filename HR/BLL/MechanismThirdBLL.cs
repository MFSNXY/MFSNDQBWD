using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using Model;
using IDAO;
using DAO;
using IBLL;

namespace BLL
{
    public class MechanismThirdBLL : IMechanismThirdBLL
    {
        IMechanismThirdDAO imd = IocCreate.CreateDao<IMechanismThirdDAO, MechanismThirdDAO>();

        public int MechanismThirdAdd(MechanismThirdModel p)
        {
            return imd.MechanismThirdAdd(p);
        }

        public MechanismThirdModel MechanismThirdBy(int id)
        {
            return imd.MechanismThirdBy(id);
        }

        public int MechanismThirdDelete(int id)
        {
            return imd.MechanismThirdDelete(id);
        }

        public List<MechanismThirdModel> MechanismThirdSelect()
        {
            return imd.MechanismThirdSelect();
        }

        public List<MechanismThirdModel> MechanismThirdSelectFirst(string firstId)
        {
            return imd.MechanismThirdSelectFirst(firstId);
        }

        public List<MechanismThirdModel> MechanismThirdSelectSecond(string secondId)
        {
            return imd.MechanismThirdSelectSecond(secondId);
        }

        public int MechanismThirdUpdate(MechanismThirdModel p)
        {
            return imd.MechanismThirdUpdate(p);
        }
    }
}
