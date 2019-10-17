using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConfigMajorModel
    {
        public int Id { get; set; }
        public string Majorkindid { get; set; }
        public string Majorkindname { get; set; }

        [Required(ErrorMessage = "职位编号不能为空")]
        public string Majorid { get; set; }
        
        [Required(ErrorMessage = "职位名称不能为空")]
        public string Majorname { get; set; }
        public int Testamount { get; set; }
    }
}
