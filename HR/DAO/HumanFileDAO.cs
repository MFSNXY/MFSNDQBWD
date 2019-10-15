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
    public class HumanFileDAO : BaseDao<HumanFile>, IHumanFileDAO
    {
        public int HumanFileAdd(HumanFileModel p)
        {
            #region
            HumanFile hf = new HumanFile() {
                AttachmentName=p.AttachmentName,
                DeleteTime=p.DeleteTime,
                BonusAmount=p.BonusAmount,
                FileChangAmount=p.FileChangAmount,
                Changer=p.Changer,
                HumanQQ=p.HumanQQ,
                ChangeTime=p.ChangeTime,
                Checker=p.Checker,
                CheckStatus=p.CheckStatus,
                CheckTime=p.CheckTime,
                FirstMid=p.FirstMid,
                DemandSalaraySum=p.DemandSalaraySum,
                FirstMName=p.FirstMName,
                HumanAccount=p.HumanAccount,
                HumanAddress=p.HumanAddress,
                HumanAge=p.HumanAge,
                HumanBank=p.HumanBank,
                HumanBirthday=p.HumanBirthday,
                MajorChangeAmount=p.MajorChangeAmount,
                HumanBirthplace=p.HumanBirthplace,
                HumanEducatedDegree=p.HumanEducatedDegree,
                HumanEducatedMajor=p.HumanEducatedMajor,
                TrainingAmount=p.TrainingAmount,
                HumanEducatedYears=p.HumanEducatedYears,
                HumanEmail=p.HumanEmail,
                HumanFamilyMembership=p.HumanFamilyMembership,
                HumanFileStatus=p.HumanFileStatus,
                HumanHistoryRecords=p.HumanHistoryRecords,
                HumanHobby=p.HumanHobby,
                HumanId=p.HumanId,
                HumanIdcard=p.HumanIdcard,
                HumanMajorId=p.HumanMajorId,
                HumanMajorKindId=p.HumanMajorKindId,
                HumanMajorKindName=p.HumanMajorKindName,
                HumanMajorName=p.HumanMajorName,
                HumanMobilephone=p.HumanMobilephone,
                RecoveryTime=p.RecoveryTime,
                HumanName=p.HumanName,
                HumanNationality=p.HumanNationality,
                HumanParty=p.HumanParty,
                HumanPicture=p.HumanPicture,
                HumanPostcode=p.HumanPostcode,
                HumanProDesignation=p.HumanProDesignation,
                HumanRace=p.HumanRace,
                HumanReligion=p.HumanReligion,
                HumanSex=p.HumanSex,
                HumanSpecility=p.HumanSpecility,
                HumanTelephone=p.HumanTelephone,
                Id=p.Id,
                LastlyChangeTime=p.LastlyChangeTime,
                PaidSalarySum=p.PaidSalarySum,
                Register=p.Register,
                RegisteTime=p.RegisteTime,
                Remark=p.Remark,
                SalaryStandardId=p.SalaryStandardId,
                SalaryStandardName=p.SalaryStandardName,
                SalaySum=p.SalaySum,
                SecondMid=p.SecondMid,
                SecondMName=p.SecondMName,
                ThirdMid=p.ThirdMid,
                ThirdMName=p.ThirdMName
            };
            #endregion
            return Add(hf);
        }

        public HumanFileModel HumanFileBy(int id)
        {
            HumanFile p = CreateContext().HumanFile.AsNoTracking().Where(e => e.Id == id).SingleOrDefault();
            #region
            HumanFileModel hf = new HumanFileModel()
            {
                AttachmentName = p.AttachmentName,
                DeleteTime = p.DeleteTime,
                BonusAmount = p.BonusAmount,
                FileChangAmount = p.FileChangAmount,
                Changer = p.Changer,
                HumanQQ = p.HumanQQ,
                ChangeTime = p.ChangeTime,
                Checker = p.Checker,
                CheckStatus = p.CheckStatus,
                CheckTime = p.CheckTime,
                FirstMid = p.FirstMid,
                DemandSalaraySum = p.DemandSalaraySum,
                FirstMName = p.FirstMName,
                HumanAccount = p.HumanAccount,
                HumanAddress = p.HumanAddress,
                HumanAge = p.HumanAge,
                HumanBank = p.HumanBank,
                HumanBirthday = p.HumanBirthday,
                MajorChangeAmount = p.MajorChangeAmount,
                HumanBirthplace = p.HumanBirthplace,
                HumanEducatedDegree = p.HumanEducatedDegree,
                HumanEducatedMajor = p.HumanEducatedMajor,
                TrainingAmount = p.TrainingAmount,
                HumanEducatedYears = p.HumanEducatedYears,
                HumanEmail = p.HumanEmail,
                HumanFamilyMembership = p.HumanFamilyMembership,
                HumanFileStatus = p.HumanFileStatus,
                HumanHistoryRecords = p.HumanHistoryRecords,
                HumanHobby = p.HumanHobby,
                HumanId = p.HumanId,
                HumanIdcard = p.HumanIdcard,
                HumanMajorId = p.HumanMajorId,
                HumanMajorKindId = p.HumanMajorKindId,
                HumanMajorKindName = p.HumanMajorKindName,
                HumanMajorName = p.HumanMajorName,
                HumanMobilephone = p.HumanMobilephone,
                RecoveryTime = p.RecoveryTime,
                HumanName = p.HumanName,
                HumanNationality = p.HumanNationality,
                HumanParty = p.HumanParty,
                HumanPicture = p.HumanPicture,
                HumanPostcode = p.HumanPostcode,
                HumanProDesignation = p.HumanProDesignation,
                HumanRace = p.HumanRace,
                HumanReligion = p.HumanReligion,
                HumanSex = p.HumanSex,
                HumanSpecility = p.HumanSpecility,
                HumanTelephone = p.HumanTelephone,
                Id = p.Id,
                LastlyChangeTime = p.LastlyChangeTime,
                PaidSalarySum = p.PaidSalarySum,
                Register = p.Register,
                RegisteTime = p.RegisteTime,
                Remark = p.Remark,
                SalaryStandardId = p.SalaryStandardId,
                SalaryStandardName = p.SalaryStandardName,
                SalaySum = p.SalaySum,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMid = p.ThirdMid,
                ThirdMName = p.ThirdMName
            };
            #endregion
            return hf;
        }

        public int HumanFileDelete(int id)
        {
            HumanFile hf = new HumanFile() { Id = id };
            return Delete(hf);
        }

        public List<HumanFileModel> HumanFileFY(int currentPage, int pageSize, out int rows)
        {
            var list = CreateContext().HumanFile.AsNoTracking().OrderBy(e => e.Id);
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<HumanFileModel> list2 = new List<HumanFileModel>();
            foreach (var p in data)
            {
                #region
                HumanFileModel hf = new HumanFileModel()
                {
                    AttachmentName = p.AttachmentName,
                    DeleteTime = p.DeleteTime,
                    BonusAmount = p.BonusAmount,
                    FileChangAmount = p.FileChangAmount,
                    Changer = p.Changer,
                    HumanQQ = p.HumanQQ,
                    ChangeTime = p.ChangeTime,
                    Checker = p.Checker,
                    CheckStatus = p.CheckStatus,
                    CheckTime = p.CheckTime,
                    FirstMid = p.FirstMid,
                    DemandSalaraySum = p.DemandSalaraySum,
                    FirstMName = p.FirstMName,
                    HumanAccount = p.HumanAccount,
                    HumanAddress = p.HumanAddress,
                    HumanAge = p.HumanAge,
                    HumanBank = p.HumanBank,
                    HumanBirthday = p.HumanBirthday,
                    MajorChangeAmount = p.MajorChangeAmount,
                    HumanBirthplace = p.HumanBirthplace,
                    HumanEducatedDegree = p.HumanEducatedDegree,
                    HumanEducatedMajor = p.HumanEducatedMajor,
                    TrainingAmount = p.TrainingAmount,
                    HumanEducatedYears = p.HumanEducatedYears,
                    HumanEmail = p.HumanEmail,
                    HumanFamilyMembership = p.HumanFamilyMembership,
                    HumanFileStatus = p.HumanFileStatus,
                    HumanHistoryRecords = p.HumanHistoryRecords,
                    HumanHobby = p.HumanHobby,
                    HumanId = p.HumanId,
                    HumanIdcard = p.HumanIdcard,
                    HumanMajorId = p.HumanMajorId,
                    HumanMajorKindId = p.HumanMajorKindId,
                    HumanMajorKindName = p.HumanMajorKindName,
                    HumanMajorName = p.HumanMajorName,
                    HumanMobilephone = p.HumanMobilephone,
                    RecoveryTime = p.RecoveryTime,
                    HumanName = p.HumanName,
                    HumanNationality = p.HumanNationality,
                    HumanParty = p.HumanParty,
                    HumanPicture = p.HumanPicture,
                    HumanPostcode = p.HumanPostcode,
                    HumanProDesignation = p.HumanProDesignation,
                    HumanRace = p.HumanRace,
                    HumanReligion = p.HumanReligion,
                    HumanSex = p.HumanSex,
                    HumanSpecility = p.HumanSpecility,
                    HumanTelephone = p.HumanTelephone,
                    Id = p.Id,
                    LastlyChangeTime = p.LastlyChangeTime,
                    PaidSalarySum = p.PaidSalarySum,
                    Register = p.Register,
                    RegisteTime = p.RegisteTime,
                    Remark = p.Remark,
                    SalaryStandardId = p.SalaryStandardId,
                    SalaryStandardName = p.SalaryStandardName,
                    SalaySum = p.SalaySum,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                #endregion
                list2.Add(hf);
            }
            return list2;
        }

        public List<HumanFileModel> HumanFileSelect()
        {
            var data = Select();
            List<HumanFileModel> list2 = new List<HumanFileModel>();
            foreach (var p in data)
            {
                #region
                HumanFileModel hf = new HumanFileModel()
                {
                    AttachmentName = p.AttachmentName,
                    DeleteTime = p.DeleteTime,
                    BonusAmount = p.BonusAmount,
                    FileChangAmount = p.FileChangAmount,
                    Changer = p.Changer,
                    HumanQQ = p.HumanQQ,
                    ChangeTime = p.ChangeTime,
                    Checker = p.Checker,
                    CheckStatus = p.CheckStatus,
                    CheckTime = p.CheckTime,
                    FirstMid = p.FirstMid,
                    DemandSalaraySum = p.DemandSalaraySum,
                    FirstMName = p.FirstMName,
                    HumanAccount = p.HumanAccount,
                    HumanAddress = p.HumanAddress,
                    HumanAge = p.HumanAge,
                    HumanBank = p.HumanBank,
                    HumanBirthday = p.HumanBirthday,
                    MajorChangeAmount = p.MajorChangeAmount,
                    HumanBirthplace = p.HumanBirthplace,
                    HumanEducatedDegree = p.HumanEducatedDegree,
                    HumanEducatedMajor = p.HumanEducatedMajor,
                    TrainingAmount = p.TrainingAmount,
                    HumanEducatedYears = p.HumanEducatedYears,
                    HumanEmail = p.HumanEmail,
                    HumanFamilyMembership = p.HumanFamilyMembership,
                    HumanFileStatus = p.HumanFileStatus,
                    HumanHistoryRecords = p.HumanHistoryRecords,
                    HumanHobby = p.HumanHobby,
                    HumanId = p.HumanId,
                    HumanIdcard = p.HumanIdcard,
                    HumanMajorId = p.HumanMajorId,
                    HumanMajorKindId = p.HumanMajorKindId,
                    HumanMajorKindName = p.HumanMajorKindName,
                    HumanMajorName = p.HumanMajorName,
                    HumanMobilephone = p.HumanMobilephone,
                    RecoveryTime = p.RecoveryTime,
                    HumanName = p.HumanName,
                    HumanNationality = p.HumanNationality,
                    HumanParty = p.HumanParty,
                    HumanPicture = p.HumanPicture,
                    HumanPostcode = p.HumanPostcode,
                    HumanProDesignation = p.HumanProDesignation,
                    HumanRace = p.HumanRace,
                    HumanReligion = p.HumanReligion,
                    HumanSex = p.HumanSex,
                    HumanSpecility = p.HumanSpecility,
                    HumanTelephone = p.HumanTelephone,
                    Id = p.Id,
                    LastlyChangeTime = p.LastlyChangeTime,
                    PaidSalarySum = p.PaidSalarySum,
                    Register = p.Register,
                    RegisteTime = p.RegisteTime,
                    Remark = p.Remark,
                    SalaryStandardId = p.SalaryStandardId,
                    SalaryStandardName = p.SalaryStandardName,
                    SalaySum = p.SalaySum,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                #endregion
                list2.Add(hf);
            }
            return list2;
        }

        public int HumanFileUpdate(HumanFileModel p)
        {
            #region
            HumanFile hf = new HumanFile()
            {
                AttachmentName = p.AttachmentName,
                DeleteTime = p.DeleteTime,
                BonusAmount = p.BonusAmount,
                FileChangAmount = p.FileChangAmount,
                Changer = p.Changer,
                HumanQQ = p.HumanQQ,
                ChangeTime = p.ChangeTime,
                Checker = p.Checker,
                CheckStatus = p.CheckStatus,
                CheckTime = p.CheckTime,
                FirstMid = p.FirstMid,
                DemandSalaraySum = p.DemandSalaraySum,
                FirstMName = p.FirstMName,
                HumanAccount = p.HumanAccount,
                HumanAddress = p.HumanAddress,
                HumanAge = p.HumanAge,
                HumanBank = p.HumanBank,
                HumanBirthday = p.HumanBirthday,
                MajorChangeAmount = p.MajorChangeAmount,
                HumanBirthplace = p.HumanBirthplace,
                HumanEducatedDegree = p.HumanEducatedDegree,
                HumanEducatedMajor = p.HumanEducatedMajor,
                TrainingAmount = p.TrainingAmount,
                HumanEducatedYears = p.HumanEducatedYears,
                HumanEmail = p.HumanEmail,
                HumanFamilyMembership = p.HumanFamilyMembership,
                HumanFileStatus = p.HumanFileStatus,
                HumanHistoryRecords = p.HumanHistoryRecords,
                HumanHobby = p.HumanHobby,
                HumanId = p.HumanId,
                HumanIdcard = p.HumanIdcard,
                HumanMajorId = p.HumanMajorId,
                HumanMajorKindId = p.HumanMajorKindId,
                HumanMajorKindName = p.HumanMajorKindName,
                HumanMajorName = p.HumanMajorName,
                HumanMobilephone = p.HumanMobilephone,
                RecoveryTime = p.RecoveryTime,
                HumanName = p.HumanName,
                HumanNationality = p.HumanNationality,
                HumanParty = p.HumanParty,
                HumanPicture = p.HumanPicture,
                HumanPostcode = p.HumanPostcode,
                HumanProDesignation = p.HumanProDesignation,
                HumanRace = p.HumanRace,
                HumanReligion = p.HumanReligion,
                HumanSex = p.HumanSex,
                HumanSpecility = p.HumanSpecility,
                HumanTelephone = p.HumanTelephone,
                Id = p.Id,
                LastlyChangeTime = p.LastlyChangeTime,
                PaidSalarySum = p.PaidSalarySum,
                Register = p.Register,
                RegisteTime = p.RegisteTime,
                Remark = p.Remark,
                SalaryStandardId = p.SalaryStandardId,
                SalaryStandardName = p.SalaryStandardName,
                SalaySum = p.SalaySum,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMid = p.ThirdMid,
                ThirdMName = p.ThirdMName
            };
            #endregion
            return Update(hf);
        }

        public int HumanFileSetPic(string hfid,string pic)
        {
           return  CreateContext().Database.ExecuteSqlCommand(string.Format("update HumanFile set HumanPicture='{0}' where HumanId='{1}'", pic, hfid));
        }

        public List<HumanFileModel> HumanFileCheckList(int currentPage, int pageSize, out int rows)
        {
            var list = CreateContext().HumanFile.AsNoTracking().Where(e=>e.CheckStatus== 0).OrderBy(e => e.Id);
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<HumanFileModel> list2 = new List<HumanFileModel>();
            foreach (var p in data)
            {
                #region
                HumanFileModel hf = new HumanFileModel()
                {
                    AttachmentName = p.AttachmentName,
                    DeleteTime = p.DeleteTime,
                    BonusAmount = p.BonusAmount,
                    FileChangAmount = p.FileChangAmount,
                    Changer = p.Changer,
                    HumanQQ = p.HumanQQ,
                    ChangeTime = p.ChangeTime,
                    Checker = p.Checker,
                    CheckStatus = p.CheckStatus,
                    CheckTime = p.CheckTime,
                    FirstMid = p.FirstMid,
                    DemandSalaraySum = p.DemandSalaraySum,
                    FirstMName = p.FirstMName,
                    HumanAccount = p.HumanAccount,
                    HumanAddress = p.HumanAddress,
                    HumanAge = p.HumanAge,
                    HumanBank = p.HumanBank,
                    HumanBirthday = p.HumanBirthday,
                    MajorChangeAmount = p.MajorChangeAmount,
                    HumanBirthplace = p.HumanBirthplace,
                    HumanEducatedDegree = p.HumanEducatedDegree,
                    HumanEducatedMajor = p.HumanEducatedMajor,
                    TrainingAmount = p.TrainingAmount,
                    HumanEducatedYears = p.HumanEducatedYears,
                    HumanEmail = p.HumanEmail,
                    HumanFamilyMembership = p.HumanFamilyMembership,
                    HumanFileStatus = p.HumanFileStatus,
                    HumanHistoryRecords = p.HumanHistoryRecords,
                    HumanHobby = p.HumanHobby,
                    HumanId = p.HumanId,
                    HumanIdcard = p.HumanIdcard,
                    HumanMajorId = p.HumanMajorId,
                    HumanMajorKindId = p.HumanMajorKindId,
                    HumanMajorKindName = p.HumanMajorKindName,
                    HumanMajorName = p.HumanMajorName,
                    HumanMobilephone = p.HumanMobilephone,
                    RecoveryTime = p.RecoveryTime,
                    HumanName = p.HumanName,
                    HumanNationality = p.HumanNationality,
                    HumanParty = p.HumanParty,
                    HumanPicture = p.HumanPicture,
                    HumanPostcode = p.HumanPostcode,
                    HumanProDesignation = p.HumanProDesignation,
                    HumanRace = p.HumanRace,
                    HumanReligion = p.HumanReligion,
                    HumanSex = p.HumanSex,
                    HumanSpecility = p.HumanSpecility,
                    HumanTelephone = p.HumanTelephone,
                    Id = p.Id,
                    LastlyChangeTime = p.LastlyChangeTime,
                    PaidSalarySum = p.PaidSalarySum,
                    Register = p.Register,
                    RegisteTime = p.RegisteTime,
                    Remark = p.Remark,
                    SalaryStandardId = p.SalaryStandardId,
                    SalaryStandardName = p.SalaryStandardName,
                    SalaySum = p.SalaySum,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                #endregion
                list2.Add(hf);
            }
            return list2;
        }

    }
}
