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
    public class SalaryGrantdetailsBLL: ISalaryGrantdetailsBLL
    {
        ISalaryGrantdetailsDAO igd = IocContainer.IocCreate.CreateDao<ISalaryGrantdetailsDAO, SalaryGrantdetailsDAO>();

        public int SalaryGrantdetailsAdd(SalaryGrantdetailsModel ck)
        {
            return igd.SalaryGrantdetailsAdd(ck);
        }

        public int SalaryGrantdetailsDelete(SalaryGrantdetailsModel ck)
        {
            return igd.SalaryGrantdetailsDelete(ck);
        }

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelect()
        {
            return igd.SalaryGrantdetailsSelect();
        }

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectBy(int id)
        {
            return igd.SalaryGrantdetailsSelectBy(id);
        }

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectID(string id)
        {
            return igd.SalaryGrantdetailsSelectID(id);
        }

        public int SalaryGrantdetailsUpdate(SalaryGrantdetailsModel ck)
        {
            return igd.SalaryGrantdetailsUpdate(ck);
        }
    }
}
