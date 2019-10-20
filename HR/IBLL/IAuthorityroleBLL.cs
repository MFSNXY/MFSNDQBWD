using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IAuthorityroleBLL
    {
        int AuthorityroleAdd(AuthorityroleModel sm);
        int AuthorityroleUpdate(AuthorityroleModel sm);
        int AuthorityroleDelete(int id);
        List<AuthorityroleModel> AuthorityroleSelect();
        List<AuthorityroleModel> SelectAuthorityroleBy(int id);
        List<AuthorityroleModel> AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows);
        int AuthorityroleDel(int oid);
        int AuthorityroleSel(int oid);
    }
}
