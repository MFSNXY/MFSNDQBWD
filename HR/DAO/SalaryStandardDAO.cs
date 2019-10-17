using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;

namespace DAO
{
    public class SalaryStandardDAO : BaseDao<SalaryStandard>, ISalaryStandardDAO
    {
        public int SalaryStandardAdd(SalaryStandardModel ck)
        {
            SalaryStandard ssd = new SalaryStandard();
            ssd.Id = ck.Id;
            ssd.Standardid = ck.Standardid;
            ssd.Standardname = ck.Standardname;
            ssd.Designer = ck.Designer;
            ssd.Register = ck.Register;
            ssd.Checker = ck.Checker;
            ssd.Changer = ck.Changer;
            ssd.Registtime = ck.Registtime;
            ssd.Checktime = DateTime.Now;
            ssd.Changetime = DateTime.Now;
            ssd.Salarysum = ck.Salarysum;
            ssd.Checkstatus = ck.Checkstatus;
            ssd.Changestatus = 1;
            ssd.Checkcomment = ck.Checkcomment;
            ssd.Remark = ck.Remark;
            return Add(ssd);
        }

        public int SalaryStandardDelete(SalaryStandardModel ck)
        {
            SalaryStandard ssd = new SalaryStandard();
            ssd.Standardid = ck.Standardid;
            ssd.Standardname = ck.Standardname;
            ssd.Designer = ck.Designer;
            ssd.Register = ck.Register;
            ssd.Checker = ck.Checker;
            ssd.Changer = ck.Changer;
            ssd.Registtime = ck.Registtime;
            ssd.Checktime = ck.Checktime;
            ssd.Changetime = ck.Changetime;
            ssd.Salarysum = ck.Salarysum;
            ssd.Checkstatus = ck.Checkstatus;
            ssd.Changestatus = ck.Changestatus;
            ssd.Checkcomment = ck.Checkcomment;
            ssd.Remark = ck.Remark;
            ssd.Id = ck.Id;
            return Delete(ssd);
        }

        public List<SalaryStandardModel> SalaryStandardFYW(int currentPage, int pageSize, out int rows, string xcid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            string sql = "select * from dbo.SalaryStandard where 1=1";
            if (xcid != null && xcid != "")
            {
                sql += string.Format(" and Standardid='{0}'", xcid);
            }
            if (gjz != null && gjz != "")
            {
                sql += string.Format(" and Standardname like '%{0}%' or Designer like '%{0}%' or Changer like '%{0}%' or Checker like '%{0}%'", gjz);
            }
            if (startTime != null && endTime != null)
            {
                sql += string.Format(" and Registtime>='{0}' and Registtime<='{1}'", startTime, endTime);
            }
            var list = CreateContext().SalaryStandard.SqlQuery(sql).OrderBy(e => e.Id).ToList();
            rows = list.Count();
            var data = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            List<SalaryStandardModel> list2 = new List<SalaryStandardModel>();
            foreach (var p in data)
            {
                SalaryStandardModel sm = new SalaryStandardModel()
                {
                    Id = p.Id,
                    Standardid = p.Standardid,
                    Standardname = p.Standardname,
                    Designer = p.Designer,
                    Register = p.Register,
                    Checker = p.Checker,
                    Changer = p.Changer,
                    Registtime = p.Registtime,
                    Checktime = p.Checktime,
                    Changetime = p.Changetime,
                    Salarysum = p.Salarysum,
                    Checkstatus = p.Checkstatus,
                    Changestatus = p.Changestatus,
                    Checkcomment = p.Checkcomment,
                    Remark = p.Remark
                };
                list2.Add(sm);
            }
            return list2;
        }

        public List<SalaryStandardModel> SalaryStandardSelect()
        {
            List<SalaryStandard> list = Select();
            List<SalaryStandardModel> list2 = new List<SalaryStandardModel>();
            foreach (SalaryStandard item in list)
            {
                SalaryStandardModel ckm = new SalaryStandardModel()
                {
                    Id = item.Id,
                    Standardid = item.Standardid,
                    Standardname = item.Standardname,
                    Designer = item.Designer,
                    Register = item.Register,
                    Checker = item.Checker,
                    Changer = item.Changer,
                    Registtime = item.Registtime,
                    Checktime = item.Checktime,
                    Changetime = item.Changetime,
                    Salarysum = item.Salarysum,
                    Checkstatus = item.Checkstatus,
                    Changestatus = item.Changestatus,
                    Checkcomment = item.Checkcomment,
                    Remark = item.Remark
            };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<SalaryStandardModel> SalaryStandardSelectBy(int id)
        {
            MyDbContext db = CreateContext();
            List<SalaryStandard> list = db.SalaryStandard.AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryStandardModel> list2 = new List<SalaryStandardModel>();
            foreach (SalaryStandard item in list)
            {
                SalaryStandardModel sm = new SalaryStandardModel()
                {
                    Id = item.Id,
                    Standardid = item.Standardid,
                    Standardname = item.Standardname,
                    Designer = item.Designer,
                    Register = item.Register,
                    Checker = item.Checker,
                    Changer = item.Changer,
                    Registtime = item.Registtime,
                    Checktime = item.Checktime,
                    Changetime = item.Changetime,
                    Salarysum = item.Salarysum,
                    Checkstatus = item.Checkstatus,
                    Changestatus = item.Changestatus,
                    Checkcomment = item.Checkcomment,
                    Remark = item.Remark
                };
                list2.Add(sm);
            }
            return list2;
        }

        public List<SalaryStandardModel> SalaryStandardSelectFY(int currentPage, int pageSize, out int rows)
        {
            string sql = "select * from dbo.SalaryStandard where Checkstatus = 0";

            var list = CreateContext().SalaryStandard.SqlQuery(sql).OrderBy(e => e.Id).ToList();
            rows = list.Count();
            var data = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            List<SalaryStandardModel> list2 = new List<SalaryStandardModel>();
            foreach (var p in data)
            {
                SalaryStandardModel sm = new SalaryStandardModel()
                {
                    Id = p.Id,
                    Standardid = p.Standardid,
                    Standardname = p.Standardname,
                    Designer = p.Designer,
                    Register = p.Register,
                    Checker = p.Checker,
                    Changer = p.Changer,
                    Registtime = p.Registtime,
                    Checktime = p.Checktime,
                    Changetime = p.Changetime,
                    Salarysum = p.Salarysum,
                    Checkstatus = p.Checkstatus,
                    Changestatus = p.Changestatus,
                    Checkcomment = p.Checkcomment,
                    Remark = p.Remark 
                };
                list2.Add(sm);
            }
            return list2;
        }

        public int SalaryStandardUpdate(SalaryStandardModel ck)
        {
            MyDbContext db = CreateContext();
            string sql = string.Format(@"update dbo.SalaryStandard set Checker='{0}',Checktime='{1}',Checkcomment='{2}',Checkstatus=1,Salarysum={3} where Id ={4}", ck.Checker,ck.Checktime,ck.Checkcomment,ck.Salarysum,ck.Id);
            
            // int list = db.Database.ExecuteSqlCommand(sql);
            int list = db.Database.ExecuteSqlCommand(sql);
            return list;
            //SalaryStandard ssd = new SalaryStandard();
            //ssd.Id = ck.Id;
            //ssd.Standardid = ck.Standardid;
            //ssd.Standardname = ck.Standardname;
            //ssd.Designer = ck.Designer;
            //ssd.Register = ck.Register;
            //ssd.Checker = ck.Checker;
            //ssd.Changer = ck.Changer;
            //ssd.Registtime = ck.Registtime;
            //ssd.Checktime = ck.Checktime;
            //ssd.Changetime = ck.Changetime;
            //ssd.Salarysum = ck.Salarysum;
            //ssd.Checkstatus = ck.Checkstatus;
            //ssd.Changestatus = ck.Changestatus;
            //ssd.Checkcomment = ck.Checkcomment;
            //ssd.Remark = ck.Remark;
            //return Update(ssd);
        }
    }
}
