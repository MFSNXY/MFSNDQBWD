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
    public class EngageDAO : BaseDao<Engage>, IEngageDAO
    {
        public int EngageAdd(EngageModel p)
        {
            Engage e = new Engage()
            {
                Id=p.Id,
                Changer=p.Changer,
                ChangeTime=p.ChangeTime,
                Claim=p.Claim,
                Deadline=p.Deadline,
                Description=p.Description,
                EngageType=p.EngageType,
                FirstMid=p.FirstMid,
                FirstMName=p.FirstMName,
                MajorId=p.MajorId,
                MajorKindid=p.MajorKindid,
                MajorKindName=p.MajorKindName,
                MajorName=p.MajorName,
                ManCount=p.ManCount,
                Register=p.Register,
                RegistTime=p.RegistTime,
                SecondMid=p.SecondMid,
                SecondMName=p.SecondMName,
                ThirdMid=p.ThirdMid,
                ThirdMName=p.ThirdMName
            };
            return Add(e);
        }

        public EngageModel EngageBy(int id)
        {
            Engage p = CreateContext().Engages.AsNoTracking().Where(e => e.Id == id).SingleOrDefault();
            return new EngageModel()
            {
                Id = p.Id,
                Changer = p.Changer,
                ChangeTime = p.ChangeTime,
                Claim = p.Claim,
                Deadline = p.Deadline,
                Description = p.Description,
                EngageType = p.EngageType,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                MajorId = p.MajorId,
                MajorKindid = p.MajorKindid,
                MajorKindName = p.MajorKindName,
                MajorName = p.MajorName,
                ManCount = p.ManCount,
                Register = p.Register,
                RegistTime = p.RegistTime,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMid = p.ThirdMid,
                ThirdMName = p.ThirdMName
            };
        }

        public int EngageDelete(int id)
        {
            Engage e = new Engage() { Id = id };
            return Delete(e);
        }

        public List<EngageModel> EngageFY(int currentPage, int pageSize, out int rows)
        {
            var list=CreateContext().Engages.AsNoTracking().OrderBy(e => e.Id);
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<EngageModel> list2 = new List<EngageModel>();
            foreach (var p in data)
            {
                EngageModel e = new EngageModel()
                {
                    Id = p.Id,
                    Changer = p.Changer,
                    ChangeTime = p.ChangeTime,
                    Claim = p.Claim,
                    Deadline = p.Deadline,
                    Description = p.Description,
                    EngageType = p.EngageType,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    MajorId = p.MajorId,
                    MajorKindid = p.MajorKindid,
                    MajorKindName = p.MajorKindName,
                    MajorName = p.MajorName,
                    ManCount = p.ManCount,
                    Register = p.Register,
                    RegistTime = p.RegistTime,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                list2.Add(e);
            }
            return list2;
        }

        public List<EngageModel> EngageSelect()
        {
            var list = Select();
            List<EngageModel> list2 = new List<EngageModel>();
            foreach (var p in list)
            {
                EngageModel e = new EngageModel()
                {
                    Id = p.Id,
                    Changer = p.Changer,
                    ChangeTime = p.ChangeTime,
                    Claim = p.Claim,
                    Deadline = p.Deadline,
                    Description = p.Description,
                    EngageType = p.EngageType,
                    FirstMid = p.FirstMid,
                    FirstMName = p.FirstMName,
                    MajorId = p.MajorId,
                    MajorKindid = p.MajorKindid,
                    MajorKindName = p.MajorKindName,
                    MajorName = p.MajorName,
                    ManCount = p.ManCount,
                    Register = p.Register,
                    RegistTime = p.RegistTime,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                list2.Add(e);
            }
            return list2;
        }

        public int EngageUpdate(EngageModel p)
        {
            Engage e = new Engage()
            {
                Id = p.Id,
                Changer = p.Changer,
                ChangeTime = p.ChangeTime,
                Claim = p.Claim,
                Deadline = p.Deadline,
                Description = p.Description,
                EngageType = p.EngageType,
                FirstMid = p.FirstMid,
                FirstMName = p.FirstMName,
                MajorId = p.MajorId,
                MajorKindid = p.MajorKindid,
                MajorKindName = p.MajorKindName,
                MajorName = p.MajorName,
                ManCount = p.ManCount,
                Register = p.Register,
                RegistTime = p.RegistTime,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMid = p.ThirdMid,
                ThirdMName = p.ThirdMName
            };
            return Update(e);
        }
    }
}
