using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IEngageResumeBLL
    {

        int EngageResumeAdd(EngageResumeModel ck);
        int EngageResumeUpdate(EngageResumeModel ck);
        int EngageResumeDelete(int id);
        List<EngageResumeModel> EngageResumeSelect();
        EngageResumeModel EngageResumeSelectBy(int id);
    }
}
