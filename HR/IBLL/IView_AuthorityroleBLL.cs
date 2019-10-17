using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IView_AuthorityroleBLL
    {
        int View_AuthorityroleAdd(View_AuthorityroleModel sm);
        int View_AuthorityroleUpdate(View_AuthorityroleModel sm);
        int View_AuthorityroleDelete(View_AuthorityroleModel sm);
        List<View_AuthorityroleModel> View_AuthorityroleSelect();
        List<View_AuthorityroleModel> SelectView_AuthorityroleBy(int id);
        List<View_AuthorityroleModel> View_AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows);
    }
}
