using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IHumanFileBLL
    {

        int HumanFileAdd(HumanFileModel p);

        int HumanFileUpdate(HumanFileModel p);

        int HumanFileDelete(int id);

        HumanFileModel HumanFileBy(int id);

        List<HumanFileModel> HumanFileSelect();

        List<HumanFileModel> HumanFileFY(int currentPage, int pageSize, out int rows);

    }
}
