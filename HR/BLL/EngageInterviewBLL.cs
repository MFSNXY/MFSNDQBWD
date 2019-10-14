using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using IBLL;
using IDAO;
using DAO;
using Model;

namespace BLL
{
    public class EngageInterviewBLL : IEngageInterviewBLL
    {
        IEngageInterviewDAO ied = IocCreate.CreateDao<IEngageInterviewDAO, EngageInterviewDAO>();

        public int EngageInterviewAdd(EngageInterviewModel p)
        {
            return ied.EngageInterviewAdd(p);
        }

        public EngageInterviewModel EngageInterviewBy(int id)
        {
            return ied.EngageInterviewBy(id);
        }

        public int EngageInterviewDelete(int id)
        {
            return ied.EngageInterviewDelete(id);
        }

        public List<EngageInterviewModel> EngageInterviewFY(int currentPage, int pageSize, out int rows)
        {
            return ied.EngageInterviewFY(currentPage, pageSize, out rows);
        }

        public List<EngageInterviewModel> EngageInterviewSelect()
        {
            return ied.EngageInterviewSelect();
        }

        public EngageInterviewModel EngageInterviewSelectResumeId(int rid)
        {
            return ied.EngageInterviewSelectResumeId(rid);
        }

        public int EngageInterviewUpdate(EngageInterviewModel p)
        {
            return ied.EngageInterviewUpdate(p);
        }


    }
}
