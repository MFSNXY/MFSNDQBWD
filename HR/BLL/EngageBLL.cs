using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using IocContainer;
using IDAO;
using DAO;

namespace BLL
{
    public class EngageBLL : IEngageBLL
    {
        IEngageDAO ied = IocCreate.CreateDao<IEngageDAO, EngageDAO>();

        public int EngageAdd(EngageModel p)
        {
            return ied.EngageAdd(p);
        }

        public EngageModel EngageBy(int id)
        {
            return ied.EngageBy(id);
        }

        public int EngageDelete(int id)
        {
            return ied.EngageDelete(id);
        }

        public List<EngageModel> EngageFY(int currentPage, int pageSize, out int rows)
        {
            return ied.EngageFY(currentPage, pageSize, out rows);
        }

        public List<EngageModel> EngageSelect()
        {
            return ied.EngageSelect();
        }

        public int EngageUpdate(EngageModel p)
        {
            return ied.EngageUpdate(p);
        }
    }
}
