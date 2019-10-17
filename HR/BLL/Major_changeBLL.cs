using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using IocContainer;
using Model;
using DAO;

namespace BLL
{
    public class Major_changeBLL:IMajor_changeBLL
    {
        IMajor_changeDAO ist = IocCreate.CreateDao<IMajor_changeDAO, Major_changeDAO>();
        public List<Major_changeModel> SelectMajor_changeBy(int id)
        {
            return ist.SelectMajor_changeBy(id);
        }

        public int Major_changeAdd(Major_changeModel sm)
        {
            return ist.Major_changeAdd(sm);
        }

        public int Major_changeDelete(Major_changeModel sm)
        {
            return ist.Major_changeDelete(sm);
        }

        public List<Major_changeModel> Major_changeFenYe(int currentPage, int PageSize, out int rows)
        {
            return ist.Major_changeFenYe(currentPage, PageSize, out rows);
        }

        public List<Major_changeModel> Major_changeSelect()
        {
            return ist.Major_changeSelect();
        }

        public int Major_changeUpdate(Major_changeModel sm)
        {
            return ist.Major_changeUpdate(sm);
        }
        public List<Major_changeModel> Major_changeSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            return ist.Major_changeSelectSX(currentPage, pageSize, out rows, mkid, mid, gjz, startTime, endTime);
        }
    }
}
