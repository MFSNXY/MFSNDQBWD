using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
using EFEntity;

namespace DAO
{
    public class MechanismSecondDAO : BaseDao<MechanismSecond>, IMechanismSecondDAO
    {
        public int MechanismSecondAdd(MechanismSecondModel p)
        {
            MechanismSecond ms = new MechanismSecond()
            {
                Id=p.Id,
                FirstMid=p.FirstMid,
                FirstMName=p.FirstMName,
                SalaryId=p.SalaryId,
                SalesId=p.SalesId,
                SecondMid=p.SecondMid,
                SecondMName=p.SecondMName
            };
            return Add(ms);
        }

        public MechanismSecondModel MechanismSecondBy(int id)
        {
             MechanismSecond p = CreateContext().MechanismSeconds.AsNoTracking().Where(e => e.Id == id).Select(e => e).SingleOrDefault();
            return new MechanismSecondModel()
            {
                Id = p.Id,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                SalaryId = p.SalaryId,
                SalesId = p.SalesId,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName
            };
        }

        public int MechanismSecondDelete(int id)
        {
            MechanismSecond m = new MechanismSecond() { Id = id };
            return Delete(m);
        }

        public List<MechanismSecondModel> MechanismSecondFY(int currentPage, int pageSize, out int rows)
        {
            var result4 = CreateContext().MechanismSeconds
                .AsNoTracking()
                .OrderBy(e => e.Id);
            rows = result4.Count();//总行数
            var data = result4//.Where(e=>e)
                 .Skip((currentPage - 1) * pageSize)//忽略多少条数
                 .Take(pageSize)//取多少条数
                 .ToList();
            List<MechanismSecond> list = data.ToList();
            List<MechanismSecondModel> list2 = new List<MechanismSecondModel>();
            foreach (var p in list)
            {
                MechanismSecondModel pp = new MechanismSecondModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    SalaryId = p.SalaryId,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<MechanismSecondModel> MechanismSecondSelect()
        {
            List<MechanismSecond> list = Select();
            List<MechanismSecondModel> list2 = new List<MechanismSecondModel>();
            foreach (var p in list)
            {
                MechanismSecondModel pp = new MechanismSecondModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    SalaryId = p.SalaryId,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<MechanismSecondModel> MechanismSecondSelectFirst(string firstId)
        {
            List<MechanismSecond> list = CreateContext().MechanismSeconds.AsNoTracking().Where(e => e.FirstMid == firstId).Select(e => e).ToList();
            List<MechanismSecondModel> list2 = new List<MechanismSecondModel>();
            foreach (var p in list)
            {
                MechanismSecondModel pp = new MechanismSecondModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    SalaryId = p.SalaryId,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName
                };
                list2.Add(pp);
            }
            return list2;
        }

        public int MechanismSecondUpdate(MechanismSecondModel p)
        {
            MechanismSecond ms = new MechanismSecond()
            {
                Id = p.Id,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                SalaryId = p.SalaryId,
                SalesId = p.SalesId,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName
            };
            return Update(ms);
        }
    }
}
