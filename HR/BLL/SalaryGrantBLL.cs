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
    class SalaryGrantBLL : ISalaryGrantBLL
    {
        ISalaryGrantDAO icd = IocContainer.IocCreate.CreateDao<ISalaryGrantDAO, SalaryGrantDAO>();

        public int SalaryGrantAdd(SalaryGrantModel ck)
        {
            return icd.SalaryGrantAdd(ck);
        }

        public int SalaryGrantDelete(SalaryGrantModel ck)
        {
            return icd.SalaryGrantDelete(ck);
        }

        public List<SalaryGrantModel> SalaryGrantFY(int currentPage, int pageSize, out int rows)
        {
            return icd.SalaryGrantFY(currentPage, pageSize, out rows);
        }

        public List<SalaryGrantModel> SalaryGrantFYW(int currentPage, int pageSize, out int rows, string xcid, string gjz, string year, string months)
        {
            return icd.SalaryGrantFYW(currentPage, pageSize, out rows, xcid, gjz, year, months);
        }

        public List<SalaryGrantModel> SalaryGrantSelect()
        {
            return icd.SalaryGrantSelect();
        }

        public List<SalaryGrantModel> SalaryGrantSelectBy(int id)
        {
            return icd.SalaryGrantSelectBy(id);
        }

        //public List<SalaryGrantModel> SalaryGrantSelectEJ()
        //{
        //    return icd.SalaryGrantSelectEJ();
        //}

        public List<SalaryGrantModel> SalaryGrantSelectEJA(string zz)
        {
            return icd.SalaryGrantSelectEJA(zz);
        }

        //public List<SalaryGrantModel> SalaryGrantSelectSJ()
        //{
        //    return icd.SalaryGrantSelectSJ();
        //}

        //public List<SalaryGrantModel> SalaryGrantSelectYJ()
        //{
        //    return icd.SalaryGrantSelectYJ();
        //}

        public int SalaryGrantUpdate(SalaryGrantModel ck)
        {
            return icd.SalaryGrantUpdate(ck);
        }

        public int SalaryGrantUpdate2(SalaryGrantModel ck)
        {
            return icd.SalaryGrantUpdate2(ck);
        }

        public string SelectFID(string fid, string sid)
        {
            return icd.SelectFID(fid, sid);
        }

        public int SelectPD(string fid, string sid)
        {
            return icd.SelectPD(fid, sid);
        }

        public int SelectPDSID(string sid, string hid)
        {
            return icd.SelectPDSID(sid, hid);
        }
    }
}
