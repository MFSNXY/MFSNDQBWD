using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using IocContainer;
using DAO;
using Model;

namespace BLL
{
    public class UsersmanBLL:IUsersmanBLL
    {
        IUsersmanDAO ist = IocCreate.CreateDao<IUsersmanDAO, UsersmanDAO>();
        public List<UsersmanModel> SelectUsersmanBy(int id)
        {
            return ist.SelectUsersmanBy(id);
        }

        public int UsersmanAdd(UsersmanModel sm)
        {
            return ist.UsersmanAdd(sm);
        }

        public int UsersmanDelete(UsersmanModel sm)
        {
            return ist.UsersmanDelete(sm);
        }

        public List<UsersmanModel> UsersmanFenYe(int currentPage, int PageSize, out int rows)
        {
            return ist.UsersmanFenYe(currentPage,PageSize,out rows);
        }

        public List<UsersmanModel> UsersmanSelect()
        {
            return ist.UsersmanSelect();
        }

        public int UsersmanUpdate(UsersmanModel sm)
        {
            return ist.UsersmanUpdate(sm);
        }
    }
}
