using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SalaryStandardModel
    {
        public int Id { get; set; }
        public string Standardid { get; set; }
        public string Standardname { get; set; }
        public string Designer { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public string Changer { get; set; }
        public DateTime Registtime { get; set; }
        public DateTime Checktime { get; set; }
        public DateTime Changetime { get; set; }
        public decimal Salarysum { get; set; }
        public int Checkstatus { get; set; }
        public int Changestatus { get; set; }
        public string Checkcomment { get; set; }
        public string Remark { get; set; }
    }
}
