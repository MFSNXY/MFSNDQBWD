using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
     public interface ISalaryStandardDetailsDAO
    {
        int SalaryStandardDetailsAdd(SalaryStandardDetailsModel ck);
        int SalaryStandardDetailsUpdate(SalaryStandardDetailsModel ck);
        int SalaryStandardDetailsDelete(SalaryStandardDetailsModel ck);
        List<SalaryStandardDetailsModel> SalaryStandardDetailsSelect();
        List<SalaryStandardDetailsModel> SalaryStandardDetailsSelectBy(int id);
        List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectGZXQ(string id);
        List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectSID(string id);
    }
}
