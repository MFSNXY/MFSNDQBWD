using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IPublicCharBLL
    {
        int PublicCharAdd(PublicCharModel sm);
        int PublicCharUpdate(PublicCharModel sm);
        int PublicCharDelete(PublicCharModel sm);
        List<PublicCharModel> PublicCharSelect();
        List<PublicCharModel> SelectPublicCharBy(int id);
        List<PublicCharModel> PublicCharFenYe<K>(int currentPage, int PageSize, out int rows);

        List<PublicCharModel> PublicCharGet(string type);
    }
}
