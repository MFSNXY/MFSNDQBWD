using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class SalaryStandardDetails
    {
        public int Id { get; set; }
        public string Standardid { get; set; }
        public string Standardname { get; set; }
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public decimal Salary { get; set; }
    }
}
