using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsersModel
    {
        public int U_id { get; set; }
        [Required(ErrorMessage = "名称不能为空<br/>")]
        public string U_name { get; set; }
        [Required(ErrorMessage = "真实名字不能为空<br/>")]
        public string U_true_name { get; set; }
        [Required(ErrorMessage = "密码不能为空<br/>")]
        public string U_password { get; set; }
        public int U_oid { get; set; }
    }
}
