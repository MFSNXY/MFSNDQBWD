using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class PublicCharModel
    {
        public int Pbc_id { get; set; }
        [Required(ErrorMessage = "属性种类不能为空<br/>")]
        public string Attribute_kind { get; set; }
        [Required(ErrorMessage = "属性名称不能为空<br/>")]
        public string Attribute_name { get; set; }
    }
}
