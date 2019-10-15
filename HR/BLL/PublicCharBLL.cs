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
    public class PublicCharBLL : IPublicCharBLL
    {
        IPublicCharDAO ist = IocCreate.CreateDao<IPublicCharDAO, PublicCharDAO>();

        public List<PublicCharModel> SelectPublicCharBy(int id)
        {
            return ist.SelectPublicCharBy(id);
        }

        public int PublicCharAdd(PublicCharModel sm)
        {
            return ist.PublicCharAdd(sm);
        }

        public int PublicCharDelete(PublicCharModel sm)
        {
            return ist.PublicCharDelete(sm);
        }

        public List<PublicCharModel> PublicCharFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<PublicCharModel> PublicCharSelect()
        {
            return ist.PublicCharSelect();
        }

        public int PublicCharUpdate(PublicCharModel sm)
        {
            return ist.PublicCharUpdate(sm);
        }

        public List<PublicCharModel> PublicCharGet(string type)
        {
            return ist.PublicCharGet(type);
        }
    }
}
