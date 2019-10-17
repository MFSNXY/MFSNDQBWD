using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class UsersmanModel
    {
        public int U_oid { get; set; }
        [Required(ErrorMessage = "名称不能为空<br/>")]
        public string U_name1 { get; set; }
        public string U_sm { get; set; }
        public string U_sf { get; set; }
    }
}
