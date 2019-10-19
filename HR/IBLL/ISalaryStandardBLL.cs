using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface ISalaryStandardBLL
    {
        int SalaryStandardAdd(SalaryStandardModel ckm);
        int SalaryStandardUpdate(SalaryStandardModel ckm);
        int SalaryStandardUpdate2(SalaryStandardModel ck);
        int SalaryStandardDelete(SalaryStandardModel ckm);
        List<SalaryStandardModel> SalaryStandardSelect();
        List<SalaryStandardModel> SalaryStandardSelectBy(int id);
        List<SalaryStandardModel> SalaryStandardSelectFY(int currentPage, int pageSize, out int rows);
        List<SalaryStandardModel> SalaryStandardFYW(int currentPage, int pageSize, out int rows, string cs, string xcid, string gjz, DateTime? startTime, DateTime? endTime);
    }
}
