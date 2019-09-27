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
    public class MechanismFirstDAO : BaseDao<MechanismFirst>, IMechanismFirstDAO
    {
        public int MechanismFirstAdd(MechanismFirstModel p)
        {
            MechanismFirst mf = new MechanismFirst()
            {
                Id=p.Id,
                FirstMId=p.FirstMId,
                FirstMName=p.FirstMName,
                SalaryId=p.SalaryId,
                SalesId=p.SalesId
            };
            return Add(mf);
        }

        public MechanismFirstModel MechanismFirstBy(int id)
        {
            MechanismFirst p = CreateContext().MechanismFirsts.AsNoTracking().Where(e => e.Id == id).SingleOrDefault();
            MechanismFirstModel mf= new MechanismFirstModel()
            {
                Id = p.Id,
                FirstMId = p.FirstMId,
                FirstMName = p.FirstMName,
                SalaryId = p.SalaryId,
                SalesId = p.SalesId
            };
            return mf;
        }

        public int MechanismFirstDelete(int id)
        {
            MechanismFirst mf = new MechanismFirst() { Id = id };
            return Delete(mf);
        }

        public List<MechanismFirstModel> MechanismFirstFY(int currentPage, int pageSize, out int rows)
        {
            var result4 = CreateContext().MechanismFirsts
                .AsNoTracking()
                .OrderBy(e => e.Id);
            rows = result4.Count();//总行数
            var data = result4//.Where(e=>e)
                 .Skip((currentPage - 1) * pageSize)//忽略多少条数
                 .Take(pageSize)//取多少条数
                 .ToList();
            List<MechanismFirst> list = data.ToList();
            List<MechanismFirstModel> list2 = new List<MechanismFirstModel>();
            foreach (var p in list)
            {
                MechanismFirstModel pp = new MechanismFirstModel()
                {
                    Id = p.Id,
                    FirstMId = p.FirstMId,
                    FirstMName = p.FirstMName,
                    SalaryId = p.SalaryId,
                    SalesId = p.SalesId
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<MechanismFirstModel> MechanismFirstSelect()
        {
            List<MechanismFirst> list = Select();
            List<MechanismFirstModel> list2 = new List<MechanismFirstModel>();
            foreach (var p in list)
            {
                MechanismFirstModel pp = new MechanismFirstModel()
                {
                    Id = p.Id,
                    FirstMId = p.FirstMId,
                    FirstMName = p.FirstMName,
                    SalaryId = p.SalaryId,
                    SalesId = p.SalesId
                };
                list2.Add(pp);
            }
            return list2;
        }

        public int MechanismFirstUpdate(MechanismFirstModel p)
        {
            MechanismFirst mf = new MechanismFirst()
            {
                Id = p.Id,
                FirstMId = p.FirstMId,
                FirstMName = p.FirstMName,
                SalaryId = p.SalaryId,
                SalesId = p.SalesId
            };
            return Update(mf);
        }
    }
}
