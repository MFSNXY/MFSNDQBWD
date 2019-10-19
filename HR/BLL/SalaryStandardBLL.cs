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
    public class SalaryStandardBLL: ISalaryStandardBLL
    {
        ISalaryStandardDAO isd = IocContainer.IocCreate.CreateDao<ISalaryStandardDAO, SalaryStandardDAO>();

        public int SalaryStandardAdd(SalaryStandardModel ckm)
        {
            return isd.SalaryStandardAdd(ckm);
        }

        public int SalaryStandardDelete(SalaryStandardModel ckm)
        {
            return isd.SalaryStandardDelete(ckm);
        }

        public List<SalaryStandardModel> SalaryStandardFYW(int currentPage, int pageSize, out int rows,string cs, string xcid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            return isd.SalaryStandardFYW(currentPage, pageSize, out rows,cs, xcid, gjz, startTime, endTime);
        }

        public List<SalaryStandardModel> SalaryStandardSelect()
        {
            return isd.SalaryStandardSelect();
        }

        public List<SalaryStandardModel> SalaryStandardSelectBy(int id)
        {
            return isd.SalaryStandardSelectBy(id);
        }

        public List<SalaryStandardModel> SalaryStandardSelectFY(int currentPage, int pageSize, out int rows)
        {
            return isd.SalaryStandardSelectFY(currentPage, pageSize, out rows);
        }

        public int SalaryStandardUpdate(SalaryStandardModel ckm)
        {
            return isd.SalaryStandardUpdate(ckm);
        }

        public int SalaryStandardUpdate2(SalaryStandardModel ck)
        {
            return isd.SalaryStandardUpdate2(ck);
        }
    }
}
