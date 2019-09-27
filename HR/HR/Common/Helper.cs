using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Common
{
    public static class Helper
    {
        public static MvcHtmlString CreateSubmit(this HtmlHelper hp)
        {
            string s = $"<input id='Submit1' type='submit' class='btn btn-default' value='提交' />";
            return MvcHtmlString.Create(s);
        }
    }
}