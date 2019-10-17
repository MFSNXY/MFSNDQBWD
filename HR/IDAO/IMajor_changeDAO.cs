using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IMajor_changeDAO
    {
        int Major_changeAdd(Major_changeModel sm);
        int Major_changeUpdate(Major_changeModel sm);
        int Major_changeDelete(Major_changeModel sm);
        List<Major_changeModel> Major_changeSelect();
        List<Major_changeModel> SelectMajor_changeBy(int id);
        List<Major_changeModel> Major_changeFenYe(int currentPage, int PageSize, out int rows);
        List<Major_changeModel> Major_changeSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime);
    }
}
