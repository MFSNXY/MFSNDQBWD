﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using EFEntity;
using Model;
using System.Data;

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
                SalarySum=p.SalarySum,
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
                SalarySum = p.SalarySum,
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
            var list = CreateContext().HumanFile.AsNoTracking().Where(e => e.CheckStatus == 0 && e.HumanFileStatus == false).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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
                    SalarySum = p.SalarySum,
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
                SalarySum = p.SalarySum,
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
            var list = CreateContext().HumanFile.AsNoTracking().Where(e=>e.CheckStatus== 0&&e.HumanFileStatus==false).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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


        public List<HumanFileModel> HumanFileQueryList(int currentPage, int pageSize, out int rows,string FirstMid,string SecondMid,string ThirdMid,string HumanMajorKindId,string HumanMajorId,DateTime? startTime,DateTime? endTime,string gjz)
        {
            string sql = "select * from HumanFile where 1=1 ";
            if (FirstMid != ""&&FirstMid != "0")
            {
                sql += string.Format(" and FirstMid ='{0}'",FirstMid);
            }
            if (SecondMid != "" && SecondMid != "0")
            {
                sql += string.Format(" and SecondMid ='{0}'", SecondMid);
            }
            if (ThirdMid != "" && ThirdMid != "0")
            {
                sql += string.Format(" and ThirdMid ='{0}'", ThirdMid);
            }
            if (HumanMajorKindId != "" && HumanMajorKindId != "0")
            {
                sql += string.Format(" and HumanMajorKindId ='{0}'", HumanMajorKindId);
            }
            if (HumanMajorId != "" && HumanMajorId != "0")
            {
                sql += string.Format(" and HumanMajorId ='{0}'", HumanMajorId);
            }
            if (startTime != null&& endTime != null)
            {
                sql += string.Format(" and RegisteTime >='{0}'  and RegisteTime <='{0}'", startTime,endTime);
            }
            if (gjz != "")
            {
                sql += string.Format(" and HumanName like '%{0}%' or HumanTelephone like '%{0}%' or HumanAddress like '%{0}%' ", gjz);
            }
            var list = CreateContext().HumanFile.SqlQuery(sql).AsNoTracking().Where(e=>e.HumanFileStatus==false).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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

        public List<HumanFileModel> HumanFileChangList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            string sql = "select * from HumanFile where 1=1 ";
            if (FirstMid != "" && FirstMid != "0")
            {
                sql += string.Format(" and FirstMid ='{0}'", FirstMid);
            }
            if (SecondMid != "" && SecondMid != "0")
            {
                sql += string.Format(" and SecondMid ='{0}'", SecondMid);
            }
            if (ThirdMid != "" && ThirdMid != "0")
            {
                sql += string.Format(" and ThirdMid ='{0}'", ThirdMid);
            }
            if (HumanMajorKindId != "" && HumanMajorKindId != "0")
            {
                sql += string.Format(" and HumanMajorKindId ='{0}'", HumanMajorKindId);
            }
            if (HumanMajorId != "" && HumanMajorId != "0")
            {
                sql += string.Format(" and HumanMajorId ='{0}'", HumanMajorId);
            }
            if (startTime != null && endTime != null)
            {
                sql += string.Format(" and RegisteTime >='{0}'  and RegisteTime <='{0}'", startTime, endTime);
            }
            if (gjz != "")
            {
                sql += string.Format(" and HumanName like '%{0}%' or HumanTelephone like '%{0}%' or HumanAddress like '%{0}%' ", gjz);
            }
            var list = CreateContext().HumanFile.SqlQuery(sql).AsNoTracking().Where(e => e.HumanFileStatus == false&&e.CheckStatus==0).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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

        public List<HumanFileModel> HumanFileDeleteList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            string sql = "select * from HumanFile where 1=1 ";
            if (FirstMid != "" && FirstMid != "0")
            {
                sql += string.Format(" and FirstMid ='{0}'", FirstMid);
            }
            if (SecondMid != "" && SecondMid != "0")
            {
                sql += string.Format(" and SecondMid ='{0}'", SecondMid);
            }
            if (ThirdMid != "" && ThirdMid != "0")
            {
                sql += string.Format(" and ThirdMid ='{0}'", ThirdMid);
            }
            if (HumanMajorKindId != "" && HumanMajorKindId != "0")
            {
                sql += string.Format(" and HumanMajorKindId ='{0}'", HumanMajorKindId);
            }
            if (HumanMajorId != "" && HumanMajorId != "0")
            {
                sql += string.Format(" and HumanMajorId ='{0}'", HumanMajorId);
            }
            if (startTime != null && endTime != null)
            {
                sql += string.Format(" and RegisteTime >='{0}'  and RegisteTime <='{0}'", startTime, endTime);
            }
            if (gjz != "")
            {
                sql += string.Format(" and HumanName like '%{0}%' or HumanTelephone like '%{0}%' or HumanAddress like '%{0}%' ", gjz);
            }
            var list = CreateContext().HumanFile.SqlQuery(sql).AsNoTracking().Where(e => e.HumanFileStatus == false&&e.CheckStatus==1).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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

        public List<HumanFileModel> HumanFileRecoveryList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            string sql = "select * from HumanFile where 1=1 ";
            if (FirstMid != "" && FirstMid != "0")
            {
                sql += string.Format(" and FirstMid ='{0}'", FirstMid);
            }
            if (SecondMid != "" && SecondMid != "0")
            {
                sql += string.Format(" and SecondMid ='{0}'", SecondMid);
            }
            if (ThirdMid != "" && ThirdMid != "0")
            {
                sql += string.Format(" and ThirdMid ='{0}'", ThirdMid);
            }
            if (HumanMajorKindId != "" && HumanMajorKindId != "0")
            {
                sql += string.Format(" and HumanMajorKindId ='{0}'", HumanMajorKindId);
            }
            if (HumanMajorId != "" && HumanMajorId != "0")
            {
                sql += string.Format(" and HumanMajorId ='{0}'", HumanMajorId);
            }
            if (startTime != null && endTime != null)
            {
                sql += string.Format(" and RegisteTime >='{0}'  and RegisteTime <='{0}'", startTime, endTime);
            }
            if (gjz != "")
            {
                sql += string.Format(" and HumanName like '%{0}%' or HumanTelephone like '%{0}%' or HumanAddress like '%{0}%' ", gjz);
            }
            var list = CreateContext().HumanFile.SqlQuery(sql).AsNoTracking().Where(e => e.HumanFileStatus == true).OrderBy(e => e.Id);
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
                    SalarySum = p.SalarySum,
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

        public List<HumanFileModel> HumanFileSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            string sql = "select * from HumanFile where 1=1 ";
            if (mkid != null && mkid != "" && mid != null && mid != "" && gjz != null && gjz != "")
            {
                sql += string.Format(" and  FirstMid={0} and SecondMid={1} and ThirdMid={2} ", mkid, mid, gjz);
            }
            if (startTime != null && endTime != null)
            {
                sql += (string.Format(" and  RegisteTime>= '{0}' and RegisteTime<='{1}' ", startTime, endTime));
            }
            var list = CreateContext().HumanFile.SqlQuery(sql).OrderBy(e => e.Id).ToList();
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            List<HumanFileModel> list2 = new List<HumanFileModel>();
            foreach (var p in data)
            {
                HumanFileModel er = new HumanFileModel()
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
                    SalarySum = p.SalarySum,
                    SecondMid = p.SecondMid,
                    SecondMName = p.SecondMName,
                    ThirdMid = p.ThirdMid,
                    ThirdMName = p.ThirdMName
                };
                list2.Add(er);
            }
            return list2;
        }
        public int HumanFileUp(string humid)
        {
            string sql = string.Format(@"update dbo.HumanFile set MajorChangeAmount+=1 where HumanId='{0}'", humid);
            int s = CreateContext().Database.ExecuteSqlCommand(sql);
            return s;
        }

        public List<SalaryGrantModel> HumanFileSelectEJ()
        {
            string sql = (@"select * ,ManCount =(
select Count(SecondMid)
from dbo.HumanFile as b
where a.SecondMid=b.SecondMid and b.Zhuangtai=0
),SumMoney=(
select Sum(SalarySum)
from HumanFile as b
where a.SecondMid=b.SecondMid
),PaidSalarySum=(
select Sum(PaidSalarySum)
from HumanFile as b
where a.SecondMid=b.SecondMid
)
from dbo.MechanismSecond  as a");
            DataTable dt = DBHelper.select(sql);
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (DataRow item in dt.Rows)
            {

                if ((int)item["ManCount"] > 0)
                {
                    SalaryGrantModel sm = new SalaryGrantModel();
                    sm.Id = (int)item["Id"];
                    sm.Firstkindid = item["FirstMid"].ToString();
                    sm.Firstkindname = item["FirstMName"].ToString();
                    sm.Secondkindid = item["SecondMid"].ToString();
                    sm.Secondkindname = item["SecondMName"].ToString();
                    sm.Humanamount = (int)item["ManCount"];
                    sm.Salarygrantid = item["SalaryId"].ToString();
                    sm.Salarystandardsum = (item["SumMoney"] == DBNull.Value ? sm.Salarystandardsum : Convert.ToDecimal(item["SumMoney"]));
                    sm.Salarypaidsum = (item["PaidSalarySum"] == DBNull.Value ? sm.Salarystandardsum : Convert.ToDecimal(item["PaidSalarySum"]));

                    list2.Add(sm);
                }
            }
            return list2;
        }

        //二级机构详情
        public List<XCFFST2Model> HumanFileSelectEJXQ(string fid)
        {
            string sql = string.Format(@"select * from dbo.XCFFST2 where SecondMid='{0}'", fid);
            DataTable dt = DBHelper.select(sql);
            List<XCFFST2Model> list2 = new List<XCFFST2Model>();
            foreach (DataRow item in dt.Rows)
            {
                XCFFST2Model sm = new XCFFST2Model();
                sm.Id = (int)item["Id"];
                sm.HumanId = item["HumanId"].ToString();
                sm.SalaryId = item["SalaryId"].ToString();
                sm.HumanName = item["HumanName"].ToString();
                sm.SalaryStandardId = item["SalaryStandardId"].ToString();
                sm.PaidSalarySum = (item["PaidSalarySum"] == DBNull.Value ? sm.PaidSalarySum : Convert.ToDecimal(item["PaidSalarySum"]));
                sm.SalaySum = (item["SalarySum"] == DBNull.Value ? sm.SalaySum : Convert.ToDecimal(item["SalarySum"]));
                list2.Add(sm);
            }
            return list2;
        }


        // 根据一级机构查询薪酬发放登记
        public List<SalaryGrantModel> HumanFileSelectYJ()
        {
            string sql = (@"select * ,ManCount =(
select Count(FirstMid)
from dbo.HumanFile as b
where a.FirstMid=b.FirstMid  and b.Zhuangtai=0
),SumMoney=(
select Sum(SalarySum)
from HumanFile as b
where a.FirstMid=b.FirstMid
),PaidSalarySum=(
select Sum(PaidSalarySum)
from HumanFile as b
where a.FirstMid=b.FirstMid
)
from MechanismFirst  as a");
            DataTable dt = DBHelper.select(sql);
            List<SalaryGrantModel> list2 = new List<SalaryGrantModel>();
            foreach (DataRow item in dt.Rows)
            {
                if ((int)item["ManCount"] > 0) { 
                    SalaryGrantModel sm = new SalaryGrantModel();
                    sm.Id = (int)item["Id"];
                    sm.Firstkindid = item["FirstMid"].ToString();
                    sm.Firstkindname = item["FirstMName"].ToString();
                    sm.Humanamount = (int)item["ManCount"];
                    sm.Salarygrantid = item["SalaryId"].ToString();
                    sm.Salarystandardsum = (item["SumMoney"] == DBNull.Value ? sm.Salarystandardsum : Convert.ToDecimal(item["SumMoney"]));
                    sm.Salarypaidsum = (item["PaidSalarySum"] == DBNull.Value ? sm.Salarystandardsum : Convert.ToDecimal(item["PaidSalarySum"]));
                    list2.Add(sm);
                }
            }
            return list2;
        }

        //一级机构详情
        public List<XCFFSTModel> HumanFileSelectYJXQ(string fid)
        {
            string sql = string.Format(@"select * from dbo.XCFFST where FirstMid='{0}'", fid);
            DataTable dt = DBHelper.select(sql);
            List<XCFFSTModel> list2 = new List<XCFFSTModel>();
            foreach (DataRow item in dt.Rows)
            {
                XCFFSTModel sm = new XCFFSTModel();
                sm.Id = (int)item["Id"];
                sm.HumanId = item["HumanId"].ToString();
                sm.SalaryId = item["SalaryId"].ToString();
                sm.HumanName = item["HumanName"].ToString();
                sm.SalaryStandardId = item["SalaryStandardId"].ToString();
                sm.PaidSalarySum = (item["PaidSalarySum"] == DBNull.Value ? sm.PaidSalarySum : Convert.ToDecimal(item["PaidSalarySum"]));
                sm.SalaySum = (item["SalarySum"] == DBNull.Value ? sm.SalaySum : Convert.ToDecimal(item["SalarySum"]));
                list2.Add(sm);
            }
            return list2;
        }

        //根据档案编号查出薪酬标准单号
        public string XCFFSTHID(string hid)
        {
            string sql = string.Format("select * from dbo.XCFFST where HumanId='{0}'", hid);
            DataTable dt = DBHelper.select(sql);
            return dt.Rows[0]["SalaryStandardId"].ToString();
        }

        /// <summary>
        /// 发工资的方法
        /// </summary>
        /// <param name="ck"></param>
        /// <returns></returns>
        public int HumanFileUpdate1(HumanFileModel ck)
        {
            MyDbContext db = CreateContext();
            string sql = string.Format(@"update dbo.HumanFile set Zhuangtai=1 where id={0}", ck.Id);

            int list = db.Database.ExecuteSqlCommand(sql);
            return list;
        }

        public int HumanFileUpdateGL()
        {
            MyDbContext db = CreateContext();
            string sql = string.Format(@"update dbo.HumanFile set Zhuangtai=0 where Zhuangtai=1");

            int list = db.Database.ExecuteSqlCommand(sql);
            return list;
        }

        public int HumanFileSetAttachmentName(string hfid, string attic)
        {
            return CreateContext().Database.ExecuteSqlCommand(string.Format("update HumanFile set AttachmentName='{0}' where HumanId='{1}'", attic, hfid));
        }

        public HumanFileModel HumanFileByid(string id)
        {
            HumanFile p = CreateContext().HumanFile.AsNoTracking().Where(e => e.HumanId == id).SingleOrDefault();
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
                SalarySum = p.SalarySum,
                SecondMid = p.SecondMid,
                SecondMName = p.SecondMName,
                ThirdMid = p.ThirdMid,
                ThirdMName = p.ThirdMName
            };
            #endregion
            return hf;
        }


    }
}
