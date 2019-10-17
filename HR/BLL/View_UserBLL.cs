using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Model;
using IDAO;
using IocContainer;
using DAO;

namespace BLL
{
    public class View_UserBLL:IView_UserBLL
    {
        IView_UserDAO ist = IocCreate.CreateDao<IView_UserDAO, View_UserDAO>();
        public List<View_UserModel> SelectView_UserBy(int id)
        {
            return ist.SelectView_UserBy(id);
        }

        public int View_UserAdd(View_UserModel sm)
        {
            return ist.View_UserAdd(sm);
        }

        public int View_UserDelete(View_UserModel sm)
        {
            return ist.View_UserDelete(sm);
        }

        public List<View_UserModel> View_UserFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<View_UserModel> View_UserSelect()
        {
            return ist.View_UserSelect();
        }

        public int View_UserUpdate(View_UserModel sm)
        {
            return ist.View_UserUpdate(sm);
        }
    }
}
