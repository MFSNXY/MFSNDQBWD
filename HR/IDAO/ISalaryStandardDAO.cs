using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface ISalaryStandardDAO
    {
        int SalaryStandardAdd(SalaryStandardModel ck);
        int SalaryStandardUpdate(SalaryStandardModel ck);
        int SalaryStandardDelete(SalaryStandardModel ck);
        List<SalaryStandardModel> SalaryStandardSelect();
        List<SalaryStandardModel> SalaryStandardSelectBy(int id);
        List<SalaryStandardModel> SalaryStandardSelectFY(int currentPage, int pageSize, out int rows);
        List<SalaryStandardModel> SalaryStandardFYW(int currentPage, int pageSize, out int rows, string xcid, string gjz, DateTime? startTime, DateTime? endTime);
    }
}
