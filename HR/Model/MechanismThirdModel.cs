using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MechanismThirdModel
    {

        public int Id { get; set; }
        public string FirstMid { get; set; }
        public string FirstMName { get; set; }
        public string SecondMid { get; set; }
        public string SecondMName { get; set; }
        public string ThirdMid { get; set; }

        [Required(ErrorMessage = "请输入机构名")]
        public string ThirdMName { get; set; }

        [Required(ErrorMessage = "请输入销售责任人编号")]
        public string SalesId { get; set; }
        public string IsRetail { get; set; }
        public string SalaryId { get; set; }
    }
}
