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

        List<EngageResumeModel> EngageResumeSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime);
        List<EngageResumeModel> EngageResumeSelectYXSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime);

        List<EngageResumeModel> EngageResumeSelectMSJL(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime);
    }
}
