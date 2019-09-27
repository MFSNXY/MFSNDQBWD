using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using EFEntity;
using Model;

namespace DAO
{
    public class MechanismThirdDAO : BaseDao<MechanismThird>, IMechanismThirdDAO
    {
        public int MechanismThirdAdd(MechanismThirdModel p)
        {
            MechanismThird mt = new MechanismThird()
            {
                Id=p.Id,
                FirstMid=p.FirstMid,
                FirstMName=p.FirstMName,
                IsRetail=p.IsRetail,
                SalesId=p.SalesId,
                SecondMid=p.SecondMid,
                SecondMName=p.SecondMName,
                ThirdMName=p.ThirdMName,
                ThirdMid=p.ThirdMid
            };
            return Add(mt);
        }

        public MechanismThirdModel MechanismThirdBy(int id)
        {
            MechanismThird p = CreateContext().MechanismThirds.Where(e => e.Id == id).SingleOrDefault();
            return new MechanismThirdModel()
            {
                Id = p.Id,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                IsRetail = p.IsRetail,
                SalesId = p.SalesId,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMName = p.ThirdMName,
                ThirdMid = p.ThirdMid
            };
        }

        public int MechanismThirdDelete(int id)
        {
            MechanismThird m = new MechanismThird() { Id = id };
            return Delete(m);
        }

        public List<MechanismThirdModel> MechanismThirdSelect()
        {
            List<MechanismThird> list = Select();
            List<MechanismThirdModel> list2 = new List<MechanismThirdModel>();
            foreach (var p in list)
            {
                MechanismThirdModel a= new MechanismThirdModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    IsRetail = p.IsRetail,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMName = p.ThirdMName,
                    ThirdMid = p.ThirdMid
                };
                list2.Add(a);
            }
            return list2;
        }

        public List<MechanismThirdModel> MechanismThirdSelectFirst(string firstId)
        {
            List<MechanismThird> list = CreateContext().MechanismThirds.AsNoTracking().Where(e => e.FirstMid == firstId).Select(e => e).ToList();
            List<MechanismThirdModel> list2 = new List<MechanismThirdModel>();
            foreach (var p in list)
            {
                MechanismThirdModel mt = new MechanismThirdModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    IsRetail = p.IsRetail,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMName = p.ThirdMName,
                    ThirdMid = p.ThirdMid
                };
                list2.Add(mt);
            }
            return list2;
        }

        public List<MechanismThirdModel> MechanismThirdSelectSecond(string secondId)
        {
            List<MechanismThird> list = CreateContext().MechanismThirds.AsNoTracking().Where(e => e.SecondMid == secondId).Select(e => e).ToList();
            List<MechanismThirdModel> list2 = new List<MechanismThirdModel>();
            foreach (var p in list)
            {
                MechanismThirdModel mt = new MechanismThirdModel()
                {
                    Id = p.Id,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    IsRetail = p.IsRetail,
                    SalesId = p.SalesId,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMName = p.ThirdMName,
                    ThirdMid = p.ThirdMid
                };
                list2.Add(mt);
            }
            return list2;
        }

        public int MechanismThirdUpdate(MechanismThirdModel p)
        {
            MechanismThird mt = new MechanismThird()
            {
                Id = p.Id,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                IsRetail = p.IsRetail,
                SalesId = p.SalesId,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMName = p.ThirdMName,
                ThirdMid = p.ThirdMid
            };
            return Update(mt);
        }
    }
}
