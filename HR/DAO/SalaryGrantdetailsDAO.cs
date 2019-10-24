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
    public class SalaryGrantdetailsDAO : BaseDao<SalaryGrantdetails>, ISalaryGrantdetailsDAO
    {
        public int SalaryGrantdetailsAdd(SalaryGrantdetailsModel ck)
        {
            SalaryGrantdetails cmj = new SalaryGrantdetails();
            cmj.Id = ck.Id;
            cmj.Salarygrantid = ck.Salarygrantid;
            cmj.Humanid = ck.Humanid;
            cmj.Humanname = ck.Humanname;
            cmj.Bounssum = ck.Bounssum;
            cmj.Salesum = ck.Salesum;
            cmj.Deductsum = ck.Deductsum;
            cmj.Salarystandardsum = ck.Salarystandardsum;
            cmj.Salarypaidsum = ck.Salarypaidsum;
            return Add(cmj);
        }

        public int SalaryGrantdetailsDelete(SalaryGrantdetailsModel ck)
        {
            SalaryGrantdetails cmj = new SalaryGrantdetails();
            cmj.Salarygrantid = ck.Salarygrantid;
            cmj.Humanid = ck.Humanid;
            cmj.Humanname = ck.Humanname;
            cmj.Bounssum = ck.Bounssum;
            cmj.Salesum = ck.Salesum;
            cmj.Deductsum = ck.Deductsum;
            cmj.Salarystandardsum = ck.Salarystandardsum;
            cmj.Salarypaidsum = ck.Salarypaidsum;
            cmj.Id = ck.Id;
            return Delete(cmj);
        }

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelect()
        {
            List<SalaryGrantdetails> list = Select();
            List<SalaryGrantdetailsModel> list2 = new List<SalaryGrantdetailsModel>();
            foreach (SalaryGrantdetails item in list)
            {
                SalaryGrantdetailsModel ckm = new SalaryGrantdetailsModel()
                {
                    Id = item.Id,
                    Salarygrantid = item.Salarygrantid,
                    Humanid = item.Humanid,
                    Humanname = item.Humanname,
                    Bounssum = item.Bounssum,
                    Salesum = item.Salesum,
                    Deductsum = item.Deductsum,
                    Salarystandardsum = item.Salarystandardsum,
                    Salarypaidsum = item.Salarypaidsum
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectBy(int id)
        {
            MyDbContext db = CreateContext();
            List<SalaryGrantdetails> list = db.SalaryGrantdetails.AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryGrantdetailsModel> list2 = new List<SalaryGrantdetailsModel>();
            foreach (SalaryGrantdetails item in list)
            {
                SalaryGrantdetailsModel sm = new SalaryGrantdetailsModel()
                {
                    Id = item.Id,
                    Salarygrantid = item.Salarygrantid,
                    Humanid = item.Humanid,
                    Humanname = item.Humanname,
                    Bounssum = item.Bounssum,
                    Salesum = item.Salesum,
                    Deductsum = item.Deductsum,
                    Salarystandardsum = item.Salarystandardsum,
                    Salarypaidsum = item.Salarypaidsum
                };
                list2.Add(sm);
            }
            return list2;
        }

      

        public List<SalaryGrantdetailsModel> SalaryGrantdetailsSelectID(string id)
        {
            MyDbContext db = CreateContext();
            List<SalaryGrantdetails> list = db.SalaryGrantdetails.AsNoTracking()
                  .Where(e => e.Salarygrantid == id)
                  .Select(e => e)
                  .ToList();
            List<SalaryGrantdetailsModel> list2 = new List<SalaryGrantdetailsModel>();
            foreach (SalaryGrantdetails item in list)
            {
                SalaryGrantdetailsModel sm = new SalaryGrantdetailsModel()
                {
                    Id = item.Id,
                    Salarygrantid = item.Salarygrantid,
                    Humanid = item.Humanid,
                    Humanname = item.Humanname,
                    Bounssum = item.Bounssum,
                    Salesum = item.Salesum,
                    Deductsum = item.Deductsum,
                    Salarystandardsum = item.Salarystandardsum,
                    Salarypaidsum = item.Salarypaidsum
                };
                list2.Add(sm);
            }
            return list2;
        }

        public int SalaryGrantdetailsUpdate(SalaryGrantdetailsModel ck)
        {

            MyDbContext db = CreateContext();
            int list = db.Database.ExecuteSqlCommand(@"update dbo.SalaryGrantdetails set Bounssum={0},Salesum={1},Deductsum={2},Salarypaidsum={3} where Id ={4}",ck.Bounssum,ck.Salesum,ck.Deductsum,ck.Salarypaidsum, ck.Id);
            return list;
            //SalaryGrantdetails cmj = new SalaryGrantdetails();
            //cmj.Id = ck.Id;
            //cmj.Salarygrantid = ck.Salarygrantid;
            //cmj.Humanid = ck.Humanid;
            //cmj.Humanname = ck.Humanname;
            //cmj.Bounssum = ck.Bounssum;
            //cmj.Salesum = ck.Salesum;
            //cmj.Deductsum = ck.Deductsum;
            //cmj.Salarystandardsum = ck.Salarystandardsum;
            //cmj.Salarypaidsum = ck.Salarypaidsum;
            //return Update(cmj);
        }
    }
}
