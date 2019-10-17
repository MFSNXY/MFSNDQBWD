using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public  class MechanismSecondModel
    {
        public int Id { get; set; }
        public string FirstMid { get; set; }
        public string FirstMName { get; set; }

        public string SecondMid { get; set; }

        [Required(ErrorMessage = "请输入机构名")]
        public string SecondMName { get; set; }

        [Required(ErrorMessage = "请输入薪酬责任人编号")]
        public string SalaryId { get; set; }

        [Required(ErrorMessage = "请输入销售责任人编号")]
        public string SalesId { get; set; }

    }
}
