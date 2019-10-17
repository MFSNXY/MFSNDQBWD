using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class StandardDetailsBLL: IStandardDetailsBLL
    {
        IStandardDetailsDAO isd = IocContainer.IocCreate.CreateDao<IStandardDetailsDAO, StandardDetailsDAO>();

        public List<StandardDetailsModel> StandardDetailsSelect()
        {
            return isd.StandardDetailsSelect();
        }
    }
}
