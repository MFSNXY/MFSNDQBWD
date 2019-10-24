using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface ISalaryGrantBLL
    {
        int SalaryGrantAdd(SalaryGrantModel ck);
        int SalaryGrantUpdate(SalaryGrantModel ck);
        int SalaryGrantUpdate2(SalaryGrantModel ck);
        int SalaryGrantDelete(SalaryGrantModel ck);
        List<SalaryGrantModel> SalaryGrantSelect();
        List<SalaryGrantModel> SalaryGrantSelectBy(int id);
        //List<SalaryGrantModel> SalaryGrantSelectYJ();
        //List<SalaryGrantModel> SalaryGrantSelectEJ();
        //List<SalaryGrantModel> SalaryGrantSelectSJ();
        int SelectPD(string fid, string sid);
        int SelectPDSID(string sid, string hid);
        string SelectFID(string fid, string sid);
        List<SalaryGrantModel> SalaryGrantSelectEJA(string zz);
        List<SalaryGrantModel> SalaryGrantFY(int currentPage, int pageSize, out int rows);
        List<SalaryGrantModel> SalaryGrantFYW(int currentPage, int pageSize, out int rows, string xcid, string gjz, DateTime? startTime, DateTime? endTime);

    }
}
