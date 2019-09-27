using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class MechanismFirstModel
    {
        public int Id { get; set; }

        public string FirstMId { get; set; }

        //[Required(ErrorMessage ="请输入机构名")]
        public string FirstMName { get; set; }

        //[Required(ErrorMessage ="请输入薪酬责任人编号")]
        //[RegularExpression(@"/^[0-9,]*$/", ErrorMessage = "含有非法字符")]
        public string SalaryId { get; set; }

        //[Required(ErrorMessage = "请输入销售责任人编号")]
        //[RegularExpression(@"/^[0-9,]*$/", ErrorMessage = "含有非法字符")]
        public string SalesId { get; set; }
    }
}
