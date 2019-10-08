using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace IDAO
{
    public interface IEngageDAO
    {
        int EngageAdd(EngageModel p);

        int EngageUpdate(EngageModel p);

        int EngageDelete(int id);

        EngageModel EngageBy(int id);

        List<EngageModel> EngageSelect();

        List<EngageModel> EngageFY(int currentPage, int pageSize, out int rows);
    }
}
