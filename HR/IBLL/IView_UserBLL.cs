using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IView_UserBLL
    {
        int View_UserAdd(View_UserModel sm);
        int View_UserUpdate(View_UserModel sm);
        int View_UserDelete(View_UserModel sm);
        List<View_UserModel> View_UserSelect();
        List<View_UserModel> SelectView_UserBy(int id);
        List<View_UserModel> View_UserFenYe<K>(int currentPage, int PageSize, out int rows);
    }
}
