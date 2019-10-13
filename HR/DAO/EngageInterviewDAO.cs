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
    public class EngageInterviewDAO : BaseDao<EngageInterview>, IEngageInterviewDAO
    {
        public int EngageInterviewAdd(EngageInterviewModel p)
        {
            EngageInterview ei = new EngageInterview()
            {
                Id=p.Id,
                EQDegree=p.EQDegree,
                IQDegree=p.IQDegree,
                CheckComment=p.CheckComment,
                MultiQualityDegree=p.MultiQualityDegree,
                Checker=p.Checker,
                CheckStatus=p.CheckStatus,
                ForeignLanguageDegree=p.ForeignLanguageDegree,
                CheckTime=p.CheckTime,
                HumanMajorId=p.HumanMajorId,
                HumanMajorKindId=p.HumanMajorKindId,
                HumanMajorKindName=p.HumanMajorKindName,
                HumanMajorName=p.HumanMajorName,
                HumanName=p.HumanName,
                ImageDegree=p.ImageDegree,
                InterviewComment=p.InterviewComment,
                InterviewCount=p.InterviewCount,
                InterviewStatus=p.InterviewStatus,
                NativeLanguageDegree=p.NativeLanguageDegree,
                Register=p.Register,
                RegisteTime=p.RegisteTime,
                ResponseSpeedDegree=p.ResponseSpeedDegree,
                Result=p.Result,
                ResumeId=p.ResumeId
            };
            return Add(ei);
        }

        public EngageInterviewModel EngageInterviewBy(int id)
        {
            EngageInterview p = CreateContext().EngageInterview.AsNoTracking().Where(e => e.Id == id).SingleOrDefault();
            return new EngageInterviewModel()
            {
                Id = p.Id,
                EQDegree = p.EQDegree,
                IQDegree = p.IQDegree,
                CheckComment = p.CheckComment,
                MultiQualityDegree = p.MultiQualityDegree,
                Checker = p.Checker,
                CheckStatus = p.CheckStatus,
                ForeignLanguageDegree = p.ForeignLanguageDegree,
                CheckTime = p.CheckTime,
                HumanMajorId = p.HumanMajorId,
                HumanMajorKindId = p.HumanMajorKindId,
                HumanMajorKindName = p.HumanMajorKindName,
                HumanMajorName = p.HumanMajorName,
                HumanName = p.HumanName,
                ImageDegree = p.ImageDegree,
                InterviewComment = p.InterviewComment,
                InterviewCount = p.InterviewCount,
                InterviewStatus = p.InterviewStatus,
                NativeLanguageDegree = p.NativeLanguageDegree,
                Register = p.Register,
                RegisteTime = p.RegisteTime,
                ResponseSpeedDegree = p.ResponseSpeedDegree,
                Result = p.Result,
                ResumeId = p.ResumeId
            };
        }

        public int EngageInterviewDelete(int id)
        {
            EngageInterview ei = new EngageInterview() { Id = id };
            return Delete(ei);
        }

        public List<EngageInterviewModel> EngageInterviewSelect()
        {
            var list = Select();
            List<EngageInterviewModel> list2 = new List<EngageInterviewModel>();
            foreach (var p in list)
            {
                EngageInterviewModel ei = new EngageInterviewModel()
                {
                    Id = p.Id,
                    EQDegree = p.EQDegree,
                    IQDegree = p.IQDegree,
                    CheckComment = p.CheckComment,
                    MultiQualityDegree = p.MultiQualityDegree,
                    Checker = p.Checker,
                    CheckStatus = p.CheckStatus,
                    ForeignLanguageDegree = p.ForeignLanguageDegree,
                    CheckTime = p.CheckTime,
                    HumanMajorId = p.HumanMajorId,
                    HumanMajorKindId = p.HumanMajorKindId,
                    HumanMajorKindName = p.HumanMajorKindName,
                    HumanMajorName = p.HumanMajorName,
                    HumanName = p.HumanName,
                    ImageDegree = p.ImageDegree,
                    InterviewComment = p.InterviewComment,
                    InterviewCount = p.InterviewCount,
                    InterviewStatus = p.InterviewStatus,
                    NativeLanguageDegree = p.NativeLanguageDegree,
                    Register = p.Register,
                    RegisteTime = p.RegisteTime,
                    ResponseSpeedDegree = p.ResponseSpeedDegree,
                    Result = p.Result,
                    ResumeId = p.ResumeId
                };
                list2.Add(ei);
            }
            return list2;
        }

        public int EngageInterviewUpdate(EngageInterviewModel p)
        {
            EngageInterview ei = new EngageInterview()
            {
                Id = p.Id,
                EQDegree = p.EQDegree,
                IQDegree = p.IQDegree,
                CheckComment = p.CheckComment,
                MultiQualityDegree = p.MultiQualityDegree,
                Checker = p.Checker,
                CheckStatus = p.CheckStatus,
                ForeignLanguageDegree = p.ForeignLanguageDegree,
                CheckTime = p.CheckTime,
                HumanMajorId = p.HumanMajorId,
                HumanMajorKindId = p.HumanMajorKindId,
                HumanMajorKindName = p.HumanMajorKindName,
                HumanMajorName = p.HumanMajorName,
                HumanName = p.HumanName,
                ImageDegree = p.ImageDegree,
                InterviewComment = p.InterviewComment,
                InterviewCount = p.InterviewCount,
                InterviewStatus = p.InterviewStatus,
                NativeLanguageDegree = p.NativeLanguageDegree,
                Register = p.Register,
                RegisteTime = p.RegisteTime,
                ResponseSpeedDegree = p.ResponseSpeedDegree,
                Result = p.Result,
                ResumeId = p.ResumeId
            };
            return Update(ei);
        }
    }
}
