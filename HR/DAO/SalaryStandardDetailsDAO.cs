using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;

namespace DAO
{
    public class SalaryStandardDetailsDAO : BaseDao<SalaryStandardDetails>, ISalaryStandardDetailsDAO
    {
        public List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectGZXQ(string id)
        {
            // string sql = "select * from dbo.SalaryGrant where Firstkindname!=''";\
            string sql = string.Format(@"select * from dbo.SalaryStandardDetails where Standardid='{0}'", id);
            DataTable dt = DBHelper.select(sql);
            List<SalaryStandardDetailsModel> list2 = new List<SalaryStandardDetailsModel>();
            foreach (DataRow item in dt.Rows)
            {
                SalaryStandardDetailsModel sm = new SalaryStandardDetailsModel();
                sm.Id = (int)item["Id"];
                //Id, , , , , 
                sm.Standardid = item["Standardid"].ToString();
                sm.Standardname = item["Standardname"].ToString();
                sm.Itemid = (int)item["Itemid"];
                sm.Itemname = item["Itemname"].ToString();
                sm.Salary = (decimal)item["Salary"];
                list2.Add(sm);
            }
            return list2;
        }

        public List<SalaryStandardDetailsModel> SalaryGrantdetailsSelectSID(string id)
        {
            MyDbContext db = CreateContext();
            List<SalaryStandardDetails> list = db.SalaryStandardDetails.AsNoTracking()
                  .Where(e => e.Standardid == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryStandardDetailsModel> list2 = new List<SalaryStandardDetailsModel>();
            foreach (SalaryStandardDetails item in list)
            {
                SalaryStandardDetailsModel ckm = new SalaryStandardDetailsModel()
                {
                    Id = item.Id,
                    Standardid = item.Standardid,
                    Standardname = item.Standardname,
                    Itemid = item.Itemid,
                    Itemname = item.Itemname,
                    Salary = item.Salary
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public int SalaryStandardDetailsAdd(SalaryStandardDetailsModel ck)
        {
            SalaryStandardDetails cmj = new SalaryStandardDetails();
            cmj.Id = ck.Id;
            cmj.Standardid = ck.Standardid;
            cmj.Standardname = ck.Standardname;
            cmj.Itemid = ck.Itemid;
            cmj.Itemname = ck.Itemname;
            cmj.Salary =ck.Salary;
            return Add(cmj);
        }

        public int SalaryStandardDetailsDelete(SalaryStandardDetailsModel ck)
        {
            SalaryStandardDetails cmj = new SalaryStandardDetails();
            cmj.Standardid = ck.Standardid;
            cmj.Standardname = ck.Standardname;
            cmj.Itemid = ck.Itemid;
            cmj.Itemname = ck.Itemname;
            cmj.Salary = ck.Salary;
            cmj.Id = ck.Id;
            return Delete(cmj);
        }

        public List<SalaryStandardDetailsModel> SalaryStandardDetailsSelect()
        {
            List<SalaryStandardDetails> list = Select();
            List<SalaryStandardDetailsModel> list2 = new List<SalaryStandardDetailsModel>();
            foreach (SalaryStandardDetails item in list)
            {
                SalaryStandardDetailsModel ckm = new SalaryStandardDetailsModel()
                {
                    Id = item.Id,
                    Standardid = item.Standardid,
                    Standardname = item.Standardname,
                    Itemid = item.Itemid,
                    Itemname = item.Itemname,
                    Salary = item.Salary
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<SalaryStandardDetailsModel> SalaryStandardDetailsSelectBy(int id)
        {
            MyDbContext db = CreateContext();
            List<SalaryStandardDetails> list = db.SalaryStandardDetails.AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryStandardDetailsModel> list2 = new List<SalaryStandardDetailsModel>();
            foreach (SalaryStandardDetails item in list)
            {
                SalaryStandardDetailsModel ckm = new SalaryStandardDetailsModel()
                {
                    Id = item.Id,
                    Standardid = item.Standardid,
                    Standardname = item.Standardname,
                    Itemid = item.Itemid,
                    Itemname = item.Itemname,
                    Salary = item.Salary
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public int SalaryStandardDetailsUpdate(SalaryStandardDetailsModel ck)
        {
            MyDbContext db = CreateContext();
            // int list = db.Database.ExecuteSqlCommand(sql);
            string sql = string.Format(@"update dbo.SalaryStandardDetails set Salary={0} where Id ={1}", ck.Salary, ck.Id);
            int list = db.Database.ExecuteSqlCommand(sql);
            return list;
          
        }
    }
}
