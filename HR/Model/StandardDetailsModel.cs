using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class StandardDetailsModel
    {
        public int Item_id { get; set; }
        [Required(ErrorMessage = "薪酬项目名称不能为空<br/>")]
        public string Item_name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StandardDetailsModel
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
    }
}
