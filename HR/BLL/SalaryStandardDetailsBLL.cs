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
    public class SalaryStandardDetailsBLL : ISalaryStandardDetailsBLL
    {
        ISalaryStandardDetailsDAO icd = IocContainer.IocCreate.CreateDao<ISalaryStandardDetailsDAO, SalaryStandardDetailsDAO>();

        public List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectGZXQ(string id)
        {
            return icd.SalaryGrantdetailsSelectGZXQ(id);
        }

        public List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectSID(string id)
        {
            return icd.SalaryGrantdetailsSelectSID(id); 
        }

        public int SalaryStandardDetailsAdd(SalaryStandardDetailsModel ck)
        {
            return icd.SalaryStandardDetailsAdd(ck);
        }

        public int SalaryStandardDetailsDelete(SalaryStandardDetailsModel ck)
        {
            return icd.SalaryStandardDetailsDelete(ck);
        }

        public List<SalaryStandardDetailsModel> SalaryStandardDetailsSelect()
        {
            return icd.SalaryStandardDetailsSelect();
        }

        public List<SalaryStandardDetailsModel> SalaryStandardDetailsSelectBy(int id)
        {
            return icd.SalaryStandardDetailsSelectBy(id);
        }

        public int SalaryStandardDetailsUpdate(SalaryStandardDetailsModel ck)
        {
            return icd.SalaryStandardDetailsUpdate(ck);
        }
    }
}
