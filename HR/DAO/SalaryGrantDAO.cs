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
    public class SalaryGrantDAO : BaseDao<SalaryGrant>, ISalaryGrantDAO
    {
        public int SalaryGrantAdd(SalaryGrantModel ck)
        {
            SalaryGrant cmj = new SalaryGrant();
            cmj.Id = ck.Id;
            cmj.Salarygrantid = ck.Salarygrantid;
            cmj.Salarystandardid = ck.Salarystandardid;
            cmj.Firstkindid = ck.Firstkindid;
            cmj.Firstkindname = ck.Firstkindname;
            cmj.Secondkindid = ck.Secondkindid;
            cmj.Secondkindname = ck.Secondkindname;
            cmj.Thirdkindid = ck.Thirdkindid;
            cmj.Thirdkindname = ck.Thirdkindname;
            cmj.Humanamount = ck.Humanamount;
            cmj.Salarystandardsum = ck.Salarystandardsum;
            cmj.Salarypaidsum = ck.Salarypaidsum;
            cmj.Register = ck.Register;
            cmj.Registtime = ck.Registtime;
            cmj.Checker = ck.Checker;
            cmj.Checktime = ck.Checktime;
            cmj.Checkstatus = ck.Checkstatus;
            return Add(cmj);
        }

        public int SalaryGrantDelete(SalaryGrantModel ck)
        {
            SalaryGrant cmj = new SalaryGrant();
            cmj.Salarygrantid = ck.Salarygrantid;
            cmj.Salarystandardid = ck.Salarystandardid;
            cmj.Firstkindid = ck.Firstkindid;
            cmj.Firstkindname = ck.Firstkindname;
            cmj.Secondkindid = ck.Secondkindid;
            cmj.Secondkindname = ck.Secondkindname;
            cmj.Thirdkindid = ck.Thirdkindid;
            cmj.Thirdkindname = ck.Thirdkindname;
            cmj.Humanamount = ck.Humanamount;
            cmj.Salarystandardsum = ck.Salarystandardsum;
            cmj.Salarypaidsum = ck.Salarypaidsum;
            cmj.Register = ck.Register;
            cmj.Registtime = ck.Registtime;
            cmj.Checker = ck.Checker;
            cmj.Checktime = ck.Checktime;
            cmj.Checkstatus = ck.Checkstatus;
            cmj.Id = ck.Id;
            return Delete(cmj);
        }

        public List<SalaryGrantModel> SalaryGrantFY(int currentPage, int pageSize, out int rows)
        {
            string sql = "select * from dbo.SalaryGrant where Checkstatus=2";
           
            var list = CreateContext().SalaryGrant.SqlQuery(sql).OrderBy(e => e.Id).ToList();
            rows = list.Count();
            var data = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (var p in data)
            {
                SalaryGrantModel pp = new SalaryGrantModel()
                {
                    Id = p.Id,
                    Salarygrantid = p.Salarygrantid,
                    Salarystandardid = p.Salarystandardid,
                    Firstkindid = p.Firstkindid,
                    Firstkindname = p.Firstkindname,
                    Secondkindid = p.Secondkindid,
                    Secondkindname = p.Secondkindname,
                    Thirdkindid = p.Thirdkindid,
                    Thirdkindname = p.Thirdkindname,
                    Humanamount = p.Humanamount,
                    Salarystandardsum = p.Salarystandardsum,
                    Salarypaidsum = p.Salarypaidsum,
                    Register = p.Register,
                    Registtime = p.Registtime,
                    Checker = p.Checker,
                    Checktime = p.Checktime,
                    Checkstatus = p.Checkstatus
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<SalaryGrantModel> SalaryGrantFYW(int currentPage, int pageSize, out int rows, string xcid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            string sql = "select * from dbo.SalaryGrant where 1=1";
            if (xcid!=null&&xcid!="")
            {
                sql += string.Format(" and Salarystandardid='{0}'", xcid);
            }
            if (gjz!=null&&gjz!="")
            {
                sql += string.Format(" and Register like '%{0}%'", gjz);
            }
            if (startTime!=null&&endTime!=null)
            {
                sql += string.Format(" and Registtime>='{0}' and Registtime<='{1}'", startTime, endTime);
            }
            var list = CreateContext().SalaryGrant.SqlQuery(sql).OrderBy(e => e.Id).ToList();
            rows = list.Count();
            var data = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (var p in data)
            {
                SalaryGrantModel pp = new SalaryGrantModel()
                {
                    Id = p.Id,
                    Salarygrantid = p.Salarygrantid,
                    Salarystandardid = p.Salarystandardid,
                    Firstkindid = p.Firstkindid,
                    Firstkindname = p.Firstkindname,
                    Secondkindid = p.Secondkindid,
                    Secondkindname = p.Secondkindname,
                    Thirdkindid = p.Thirdkindid,
                    Thirdkindname = p.Thirdkindname,
                    Humanamount = p.Humanamount,
                    Salarystandardsum = p.Salarystandardsum,
                    Salarypaidsum = p.Salarypaidsum,
                    Register = p.Register,
                    Registtime = p.Registtime,
                    Checker = p.Checker,
                    Checktime = p.Checktime,
                    Checkstatus = p.Checkstatus
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<SalaryGrantModel> SalaryGrantSelect()
        {
            List<SalaryGrant> list = Select();
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (SalaryGrant item in list)
            {
                SalaryGrantModel ckm = new SalaryGrantModel()
                {
                    Id = item.Id,
                    Salarygrantid = item.Salarygrantid,
                    Salarystandardid = item.Salarystandardid,
                    Firstkindid = item.Firstkindid,
                    Firstkindname = item.Firstkindname,
                    Secondkindid = item.Secondkindid,
                    Secondkindname = item.Secondkindname,
                    Thirdkindid = item.Thirdkindid,
                    Thirdkindname = item.Thirdkindname,
                    Humanamount = item.Humanamount,
                    Salarystandardsum = item.Salarystandardsum,
                    Salarypaidsum = item.Salarypaidsum,
                    Register = item.Register,
                    Registtime = item.Registtime,
                    Checker = item.Checker,
                    Checktime = item.Checktime,
                    Checkstatus = item.Checkstatus
            };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<SalaryGrantModel> SalaryGrantSelectBy(int id)
        {
            MyDbContext db = CreateContext();
            List<SalaryGrant> list = db.SalaryGrant.AsNoTracking()
                  // List<SalaryGrant> list = db.SalaryGrant.SqlQuery().AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (SalaryGrant item in list)
            {
                SalaryGrantModel sm = new SalaryGrantModel()
                {
                    Id = item.Id,
                    Salarygrantid = item.Salarygrantid,
                    Salarystandardid = item.Salarystandardid,
                    Firstkindid = item.Firstkindid,
                    Firstkindname = item.Firstkindname,
                    Secondkindid = item.Secondkindid,
                    Secondkindname = item.Secondkindname,
                    Thirdkindid = item.Thirdkindid,
                    Thirdkindname = item.Thirdkindname,
                    Humanamount = item.Humanamount,
                    Salarystandardsum = item.Salarystandardsum,
                    Salarypaidsum = item.Salarypaidsum,
                    Register = item.Register,
                    Registtime = item.Registtime,
                    Checker = item.Checker,
                    Checktime = item.Checktime,
                    Checkstatus = item.Checkstatus
                };
                list2.Add(sm);
            }
            return list2;
        }

        public List<SalaryGrantModel> SalaryGrantSelectEJ()
        {
            string sql = "select * from dbo.SalaryGrant where Secondkindname!='' and Checkstatus=1";
            DataTable dt = DBHelper.select(sql);
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (DataRow item in dt.Rows)
            {
                SalaryGrantModel sm = new SalaryGrantModel()
                {
                    Id = (int)item["Id"],
                    Salarygrantid = item["Salarygrantid"].ToString(),
                    Salarystandardid = item["Salarystandardid"].ToString(),
                    Firstkindid = item["Firstkindid"].ToString(),
                    Firstkindname = item["Firstkindname"].ToString(),
                    Secondkindid = item["Secondkindid"].ToString(),
                    Secondkindname = item["Secondkindname"].ToString(),
                    Thirdkindid = item["Thirdkindid"].ToString(),
                    Thirdkindname = item["Thirdkindname"].ToString(),
                    Humanamount = (int)item["Humanamount"],
                    Salarystandardsum = (decimal)item["Salarystandardsum"],
                    Salarypaidsum = (decimal)item["Salarypaidsum"],
                    Register = item["Register"].ToString(),
                    Registtime = (DateTime)item["Registtime"]
                };
                list2.Add(sm);
            }
            return list2;
        }
        

        public List<SalaryGrantModel> SalaryGrantSelectSJ()
        {
            string sql = "select * from dbo.SalaryGrant where Thirdkindname!=''  and Checkstatus=1";
            DataTable dt = DBHelper.select(sql);
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (DataRow item in dt.Rows)
            {
                SalaryGrantModel sm = new SalaryGrantModel()
                {
                    Id = (int)item["Id"],
                    Salarygrantid = item["Salarygrantid"].ToString(),
                    Salarystandardid = item["Salarystandardid"].ToString(),
                    Firstkindid = item["Firstkindid"].ToString(),
                    Firstkindname = item["Firstkindname"].ToString(),
                    Secondkindid = item["Secondkindid"].ToString(),
                    Secondkindname = item["Secondkindname"].ToString(),
                    Thirdkindid = item["Thirdkindid"].ToString(),
                    Thirdkindname = item["Thirdkindname"].ToString(),
                    Humanamount = (int)item["Humanamount"],
                    Salarystandardsum = (decimal)item["Salarystandardsum"],
                    Salarypaidsum = (decimal)item["Salarypaidsum"],
                    Register = item["Register"].ToString(),
                    Registtime = (DateTime)item["Registtime"]
                };
                list2.Add(sm);
            }
            return list2;
        }

        public List<SalaryGrantModel> SalaryGrantSelectYJ()
        {
            string sql = "select * from dbo.SalaryGrant where Firstkindname!=''  and Checkstatus=1";
            DataTable dt = DBHelper.select(sql);
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (DataRow item in dt.Rows)
            {
                SalaryGrantModel sm = new SalaryGrantModel();
                sm.Id = (int)item["Id"];
                sm.Salarygrantid = item["Salarygrantid"].ToString();
                sm.Salarystandardid = item["Salarystandardid"].ToString();
                sm.Firstkindid = item["Firstkindid"].ToString();
                sm.Firstkindname = item["Firstkindname"].ToString();
                sm.Secondkindid = item["Secondkindid"].ToString();
                sm.Secondkindname = item["Secondkindname"].ToString();
                sm.Thirdkindid = item["Thirdkindid"].ToString();
                sm.Thirdkindname = item["Thirdkindname"].ToString();
                sm.Humanamount = (int)item["Humanamount"];
                sm.Salarystandardsum = (decimal)item["Salarystandardsum"];
                sm.Salarypaidsum = (decimal)item["Salarypaidsum"];
                sm.Register = item["Register"].ToString();
                sm.Registtime = (DateTime)item["Registtime"];
                list2.Add(sm);
            }
            return list2;
        }

        public int SalaryGrantUpdate(SalaryGrantModel ck)
        {
           
            MyDbContext db = CreateContext();
            // int list = db.Database.ExecuteSqlCommand(sql);
            int list = db.Database.ExecuteSqlCommand(@"update dbo.SalaryGrant set Salarypaidsum={0},Register={1},Registtime={2},Checker={3},
Checktime = {4},Checkstatus={5} where Id ={6}", ck.Salarypaidsum, ck.Register, ck.Registtime, ck.Checker, ck.Checktime, ck.Checkstatus, ck.Id);
            return list;
            //SalaryGrant cmj = new SalaryGrant();
            //cmj.Id = ck.Id;
            // cmj.Salarystandardid = ck.Salarystandardid;
            // cmj.Firstkindid = ck.Firstkindid;
            //cmj.Firstkindname = ck.Firstkindname;
            // cmj.Secondkindid = ck.Secondkindid;
            //cmj.Secondkindname = ck.Secondkindname;
            //cmj.Thirdkindid = ck.Thirdkindid;
            //cmj.Thirdkindname = ck.Thirdkindname;
            // cmj.Humanamount = ck.Humanamount;
            //cmj.Salarystandardsum = ck.Salarystandardsum;
            //cmj.Salarygrantid = ck.Salarygrantid;
            //cmj.Salarypaidsum = ck.Salarypaidsum;
            //cmj.Register = ck.Register;
            //cmj.Registtime = ck.Registtime;
            //cmj.Checker = ck.Checker;
            // cmj.Checktime = ck.Checktime;
            //cmj.Checkstatus = ck.Checkstatus;
            //return Update(cmj);
        }
    }
}
