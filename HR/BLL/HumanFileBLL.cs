using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using Model;
using IDAO;
using DAO;
using IBLL;

namespace BLL
{
    public class HumanFileBLL : IHumanFileBLL
    {
        IHumanFileDAO ihd = IocCreate.CreateDao<IHumanFileDAO, HumanFileDAO>();

        public int HumanFileAdd(HumanFileModel p)
        {
            return ihd.HumanFileAdd(p);
        }

        public HumanFileModel HumanFileBy(int id)
        {
            return ihd.HumanFileBy(id);
        }

        public int HumanFileDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<HumanFileModel> HumanFileFY(int currentPage, int pageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<HumanFileModel> HumanFileSelect()
        {
            throw new NotImplementedException();
        }

        public int HumanFileUpdate(HumanFileModel p)
        {
            throw new NotImplementedException();
        }
    }
}
