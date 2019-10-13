using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EngageInterviewModel
    {

        public int Id { get; set; }
        public string HumanName { get; set; }
        public int InterviewCount { get; set; }
        public string HumanMajorKindId { get; set; }
        public string HumanMajorKindName { get; set; }
        public string HumanMajorId { get; set; }
        public string HumanMajorName { get; set; }
        public string ImageDegree { get; set; }
        public string NativeLanguageDegree { get; set; }
        public string ForeignLanguageDegree { get; set; }
        public string ResponseSpeedDegree { get; set; }
        public string EQDegree { get; set; }
        public string IQDegree { get; set; }
        public string MultiQualityDegree { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }

        public DateTime RegisteTime { get; set; }

        public DateTime CheckTime { get; set; }
        public int ResumeId { get; set; }
        public string Result { get; set; }
        public string InterviewComment { get; set; }

        public string CheckComment { get; set; }

        public int InterviewStatus { get; set; }

        public int CheckStatus { get; set; }

    }
}
