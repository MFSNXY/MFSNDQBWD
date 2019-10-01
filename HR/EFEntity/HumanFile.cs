using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class HumanFile
    {
        public int Id { get; set; }
        public string HumanId { get; set; }
        public string FirstMid { get; set; }
        public string FirstMName { get; set; }
        public string SecondMid { get; set; }
        public string SecondMName { get; set; }
        public string ThirdMid { get; set; }
        public string ThirdMName { get; set; }
        public string HumanName { get; set; }
        public string HumanAddress { get; set; }
        public string HumanPostcode { get; set; }
        public string HumanProDesignation { get; set; }
        public string HumanMajorKindId { get; set; }
        public string HumanMajorKindName { get; set; }
        public string HumanMajorId { get; set; }
        public string HumanMajorName { get; set; }
        public string HumanTelephone { get; set; }
        public string HumanMobilephone { get; set; }
        public string HumanBank { get; set; }
        public string HumanAccount { get; set; }
        public string HumanQQ { get; set; }
        public string HumanEmail { get; set; }
        public string HumanHobby { get; set; }
        public string HumanSpecility { get; set; }
        public string HumanSex { get; set; }
        public string HumanReligion { get; set; }
        public string HumanParty { get; set; }
        public string HumanNationality { get; set; }
        public string HumanRace { get; set; }
        public DateTime HumanBirthday { get; set; }
        public string HumanBirthplace { get; set; }
        public int HumanAge { get; set; }
        public string HumanEducatedDegree { get; set; }
        public int HumanEducatedYears { get; set; }
        public string HumanEducatedMajor { get; set; }
        public string HumanIdcard { get; set; }
        public string Remark { get; set; }
        public string SalaryStandardId { get; set; }
        public string SalaryStandardName { get; set; }
        public decimal SalarySum { get; set; }
        public decimal DemandSalaraySum { get; set; }
        public decimal PaidSalarySum { get; set; }
        public Int16 MajorChangeAmount { get; set; }
        public Int16 BonusAmount { get; set; }
        public Int16 TrainingAmount { get; set; }
        public Int16 FileChangAmount { get; set; }
        public string HumanHistoryRecords { get; set; }
        public string HumanFamilyMembership { get; set; }
        public string HumanPicture { get; set; }
        public string AttachmentName { get; set; }
        public Int16 CheckStatus { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public string Changer { get; set; }
        public DateTime RegisteTime { get; set; }
        public DateTime CheckTime { get; set; }
        public DateTime ChangeTime { get; set; }
        public DateTime LastlyChangeTime { get; set; }
        public DateTime DeleteTime { get; set; }
        public DateTime RecoveryTime { get; set; }
        public bool HumanFileStatus { get; set; }

        public string HumanSocietySecurityId { get; set; }

        public int Zhuangtai { get; set; }
    }
}
