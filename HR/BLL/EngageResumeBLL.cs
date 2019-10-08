using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using Model;
using IDAO;
using IBLL;
using DAO;

namespace BLL
{
    public class EngageResumeBLL : IEngageResumeBLL
    {
        IEngageResumeDAO ied = IocCreate.CreateDao<IEngageResumeDAO, EngageResumeDAO>();

        public int EngageResumeAdd(EngageResumeModel ck)
        {
            return ied.EngageResumeAdd(ck);
        }

        public int EngageResumeDelete(int id)
        {
            return ied.EngageResumeDelete(id);
        }

        public List<EngageResumeModel> EngageResumeSelect()
        {
            return ied.EngageResumeSelect();
        }

        public EngageResumeModel EngageResumeSelectBy(int id)
        {
            return ied.EngageResumeBy(id);
        }

        public int EngageResumeUpdate(EngageResumeModel ck)
        {
            return ied.EngageResumeUpdate(ck);
        }
    }
}
