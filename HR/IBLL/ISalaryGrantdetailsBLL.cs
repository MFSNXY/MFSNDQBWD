using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface ISalaryGrantdetailsBLL
    {
        int SalaryGrantdetailsAdd(SalaryGrantdetailsModel ck);
        int SalaryGrantdetailsUpdate(SalaryGrantdetailsModel ck);
        int SalaryGrantdetailsDelete(SalaryGrantdetailsModel ck);
        List<SalaryGrantdetailsModel> SalaryGrantdetailsSelect();
        List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectBy(int id);
        List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectID(string id);
    }
}
