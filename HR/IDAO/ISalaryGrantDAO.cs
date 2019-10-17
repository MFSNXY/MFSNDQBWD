using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface ISalaryGrantDAO
    {
        int SalaryGrantAdd(SalaryGrantModel ck);
        int SalaryGrantUpdate(SalaryGrantModel ck);
        int SalaryGrantDelete(SalaryGrantModel ck);
        List<SalaryGrantModel> SalaryGrantSelect();
        List<SalaryGrantModel> SalaryGrantSelectBy(int id);
        List<SalaryGrantModel> SalaryGrantSelectYJ();
        List<SalaryGrantModel> SalaryGrantSelectEJ();
        List<SalaryGrantModel> SalaryGrantSelectSJ();
        List<SalaryGrantModel> SalaryGrantFY(int currentPage, int pageSize, out int rows);

        List<SalaryGrantModel> SalaryGrantFYW(int currentPage, int pageSize, out int rows,string xcid,string gjz,DateTime? startTime,DateTime? endTime);
    }
}
