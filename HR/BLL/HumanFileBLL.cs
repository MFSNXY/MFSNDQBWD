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
            return ihd.HumanFileDelete(id);
        }

        public List<HumanFileModel> HumanFileFY(int currentPage, int pageSize, out int rows)
        {
            return ihd.HumanFileFY(currentPage, pageSize, out rows);
        }

        public List<HumanFileModel> HumanFileSelect()
        {
            return ihd.HumanFileSelect();
        }

        public int HumanFileSetPic(string hfid, string pic)
        {
            return ihd.HumanFileSetPic(hfid, pic);
        }

        public int HumanFileUpdate(HumanFileModel p)
        {
            return ihd.HumanFileUpdate(p);
        }
        
        public List<HumanFileModel> HumanFileCheckList(int currentPage, int pageSize, out int rows)
        {
            return ihd.HumanFileCheckList(currentPage, pageSize, out rows);
        }

    }
}
