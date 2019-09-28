using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IocContainer;
using DAO;

namespace BLL
{
    public class StandardDetailsBLL:IStandardDetailsBLL
    {
        IStandardDetailsDAO ist = IocCreate.CreateDao<IStandardDetailsDAO, StandardDetailsDAO>();

        public List<StandardDetailsModel> SelectStandardDetailsBy(int id)
        {
            return ist.SelectStandardDetailsBy(id);
        }

        public int StandardDetailsAdd(StandardDetailsModel sm)
        {
            return ist.StandardDetailsAdd(sm);
        }

        public int StandardDetailsDelete(StandardDetailsModel sm)
        {
            return ist.StandardDetailsDelete(sm);
        }

        public List<StandardDetailsModel> StandardDetailsFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<StandardDetailsModel> StandardDetailsSelect()
        {
            return ist.StandardDetailsSelect();
        }

        public int StandardDetailsUpdate(StandardDetailsModel sm)
        {
            return ist.StandardDetailsUpdate(sm);
        }
    }
}
