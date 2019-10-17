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
    public class UsersBLL : IUsersBLL
    {
        IUsersDAO ist = IocCreate.CreateDao<IUsersDAO, UsersDAO>();
        public List<UsersModel> SelectUsersBy(int id)
        {
            return ist.SelectUsersBy(id);
        }

        public int UsersAdd(UsersModel sm)
        {
            return ist.UsersAdd(sm);
        }

        public int UsersDelete(UsersModel sm)
        {
            return ist.UsersDelete(sm);
        }

        public List<UsersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<UsersModel> UsersSelect()
        {
            return ist.UsersSelect();
        }

        public int UsersUpdate(UsersModel sm)
        {
            return ist.UsersUpdate(sm);
        }
    }
}
