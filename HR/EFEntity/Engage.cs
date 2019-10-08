using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class Engage
    {
        public int Id { get; set; }

        public string FirstMid { get; set; }
        
        public string FirstMName { get; set; }
        
        public string SecondMid { get; set; }

        public string SecondMName { get; set; }

        public string ThirdMid { get; set; }

        public string ThirdMName { get; set; }

        public int MajorKindid { get; set; }

        public string MajorKindName { get; set; }

        public string MajorId { get; set; }

        public string MajorName { get; set; }

        public int ManCount { get; set; }

        public string EngageType { get; set; }

        public DateTime Deadline { get; set; }

        public string Register { get; set; }

        public string Changer { get; set; }

        public DateTime RegistTime { get; set; }

        public DateTime ChangeTime { get; set; }

        public string Description { get; set; }

        public string Claim { get; set; }

    }
}
