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
    public class AuthorityroleBLL:IAuthorityroleBLL
    {
        IAuthorityroleDAO ist = IocCreate.CreateDao<IAuthorityroleDAO, AuthorityroleDAO>();

        public List<AuthorityroleModel> SelectAuthorityroleBy(int id)
        {
            return ist.SelectAuthorityroleBy(id);
        }

        public int AuthorityroleAdd(AuthorityroleModel sm)
        {
            return ist.AuthorityroleAdd(sm);
        }

        public int AuthorityroleDelete(int id)
        {
            return ist.AuthorityroleDelete(id);
        }

        public List<AuthorityroleModel> AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<AuthorityroleModel> AuthorityroleSelect()
        {
            return ist.AuthorityroleSelect();
        }

        public int AuthorityroleUpdate(AuthorityroleModel sm)
        {
            return ist.AuthorityroleUpdate(sm);
        }
        public int AuthorityroleDel(int oid)
        {
            return ist.AuthorityroleDel(oid);
        }
        public int AuthorityroleSel(int oid)
        {
            return ist.AuthorityroleSel(oid);
        }
    }
}
