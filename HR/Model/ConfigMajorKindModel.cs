using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConfigMajorKindModel
    {
        public int Id { get; set; }
        public string Majorkindid { get; set; }


        [Required(ErrorMessage = "名字不能为空")]
        public string Majorkindname { get; set; }
    }
}
