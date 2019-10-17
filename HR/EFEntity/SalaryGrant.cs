using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class SalaryGrant
    {
        public int Id { get; set; }
        public string Salarygrantid { get; set; }
        public string Salarystandardid { get; set; }
        public string Firstkindid { get; set; }
        public string Firstkindname { get; set; }
        public string Secondkindid { get; set; }
        public string Secondkindname { get; set; }
        public string Thirdkindid { get; set; }
        public string Thirdkindname { get; set; }
        public int Humanamount { get; set; }
        public decimal Salarystandardsum { get; set; }
        public decimal Salarypaidsum { get; set; }
        public string Register { get; set; }
        public DateTime Registtime { get; set; }
        public string Checker { get; set; }
        public DateTime Checktime { get; set; }
        public int Checkstatus { get; set; }
    }
}
