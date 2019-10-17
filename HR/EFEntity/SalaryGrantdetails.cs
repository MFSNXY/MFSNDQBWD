using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class SalaryGrantdetails
    {
        public int Id { get; set; }
        public string Salarygrantid { get; set; }
        public string Humanid { get; set; }
        public string Humanname { get; set; }
        public decimal Bounssum { get; set; }
        public decimal Salesum { get; set; }
        public decimal Deductsum { get; set; }
        public decimal Salarystandardsum { get; set; }
        public decimal Salarypaidsum { get; set; }
    }
}
