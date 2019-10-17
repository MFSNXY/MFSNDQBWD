using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IUsersDAO
    {
        int UsersAdd(UsersModel sm);
        int UsersUpdate(UsersModel sm);
        int UsersDelete(UsersModel sm);
        List<UsersModel> UsersSelect();
        List<UsersModel> SelectUsersBy(int id);
        List<UsersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows);
    }
}
