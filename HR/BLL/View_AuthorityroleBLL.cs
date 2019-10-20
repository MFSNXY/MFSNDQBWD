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
    public class View_AuthorityroleBLL:IView_AuthorityroleBLL
    {
        IView_AuthorityroleDAO ist = IocCreate.CreateDao<IView_AuthorityroleDAO, View_AuthorityroleDAO>();

        public List<View_AuthorityroleModel> SelectView_AuthorityroleBy(int id)
        {
            return ist.SelectView_AuthorityroleBy(id);
        }

        public int View_AuthorityroleAdd(View_AuthorityroleModel sm)
        {
            return ist.View_AuthorityroleAdd(sm);
        }

        public int View_AuthorityroleDelete(View_AuthorityroleModel sm)
        {
            return ist.View_AuthorityroleDelete(sm);
        }

        public List<View_AuthorityroleModel> View_AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<View_AuthorityroleModel> View_AuthorityroleSelect()
        {
            return ist.View_AuthorityroleSelect();
        }

        public int View_AuthorityroleUpdate(View_AuthorityroleModel sm)
        {
            return ist.View_AuthorityroleUpdate(sm);
        }
    }
}
