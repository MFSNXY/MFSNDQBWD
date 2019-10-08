using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public  class EngageModel
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

        [Required(ErrorMessage ="请输入招聘人数")]
        [RegularExpression(@"\d+",ErrorMessage ="请输入数字")]
        public int ManCount { get; set; }

        public string EngageType { get; set; }

        [Required(ErrorMessage ="请输入截止日期")]
        [RegularExpression(@"((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))",
                            ErrorMessage ="请输入合法日期")]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage ="请输入登记人")]
        public string Register { get; set; }

        [Required(ErrorMessage = "请输入变更人")]
        public string Changer { get; set; }

        public DateTime RegistTime { get; set; }
        
        public DateTime ChangeTime { get; set; }

        [Required(ErrorMessage ="请输入职位描述")]
        public string Description { get; set; }

        [Required(ErrorMessage ="请输入招聘要求")]
        public string Claim { get; set; }

    }
}
