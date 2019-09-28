using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IStandardDetailsDAO
    {
        int StandardDetailsAdd(StandardDetailsModel sm);
        int StandardDetailsUpdate(StandardDetailsModel sm);
        int StandardDetailsDelete(StandardDetailsModel sm);
        List<StandardDetailsModel> StandardDetailsSelect();
        List<StandardDetailsModel> SelectStandardDetailsBy(int id);
        List<StandardDetailsModel> StandardDetailsFenYe<K>(int currentPage, int PageSize, out int rows);
    }
}
