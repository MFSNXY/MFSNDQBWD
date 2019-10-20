using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IUsersmanDAO
    {
        int UsersmanAdd(UsersmanModel sm);
        int UsersmanUpdate(UsersmanModel sm);
        int UsersmanDelete(UsersmanModel sm);
        List<UsersmanModel> UsersmanSelect();
        List<UsersmanModel> SelectUsersmanBy(int id);
        List<UsersmanModel> UsersmanFenYe(int currentPage, int PageSize, out int rows);
    }
}
