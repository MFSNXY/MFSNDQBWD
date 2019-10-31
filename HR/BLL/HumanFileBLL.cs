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

        public List<HumanFileModel> HumanFileQueryList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            return ihd.HumanFileQueryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
        }

        public List<HumanFileModel> HumanFileDeleteList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            return ihd.HumanFileDeleteList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
        }

        public List<HumanFileModel> HumanFileRecoveryList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            return ihd.HumanFileRecoveryList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
        }

        public List<HumanFileModel> HumanFileSelectSX(int currentPage, int pageSize, out int rows, string mkid, string mid, string gjz, DateTime? startTime, DateTime? endTime)
        {
            return ihd.HumanFileSelectSX(currentPage, pageSize, out rows, mkid, mid, gjz, startTime, endTime);
        }
        public int HumanFileUp(string humid)
        {
            return ihd.HumanFileUp(humid);
        }

        public List<HumanFileModel> HumanFileChangList(int currentPage, int pageSize, out int rows, string FirstMid, string SecondMid, string ThirdMid, string HumanMajorKindId, string HumanMajorId, DateTime? startTime, DateTime? endTime, string gjz)
        {
            return ihd.HumanFileChangList(currentPage, pageSize, out rows, FirstMid, SecondMid, ThirdMid, HumanMajorKindId, HumanMajorId, startTime, endTime, gjz);
        }

        public List<SalaryGrantModel> HumanFileSelectEJ()
        {
            return ihd.HumanFileSelectEJ();
        }

        public List<XCFFST2Model> HumanFileSelectEJXQ(string fid)
        {
            return ihd.HumanFileSelectEJXQ(fid);
        }

        public List<SalaryGrantModel> HumanFileSelectYJ()
        {
            return ihd.HumanFileSelectYJ();
        }

        public List<XCFFSTModel> HumanFileSelectYJXQ(string fid)
        {
            return ihd.HumanFileSelectYJXQ(fid);
        }

        public string XCFFSTHID(string hid)
        {
            return ihd.XCFFSTHID(hid);
        }

        public int HumanFileUpdate1(HumanFileModel ck)
        {
            return ihd.HumanFileUpdate1(ck);
        }

        public int HumanFileUpdateGL()
        {
            return ihd.HumanFileUpdateGL();
        }

        public int HumanFileSetAttachmentName(string hfid, string attic)
        {
            return ihd.HumanFileSetAttachmentName(hfid, attic);
        }

        public HumanFileModel HumanFileByid(string id)
        {
            return ihd.HumanFileByid(id);
        }

        public List<SalaryGrantModel> HumanFileSelectSJ()
        {
            return ihd.HumanFileSelectSJ();
        }

        public List<XCFFST3Model> HumanFileSelectSJXQ(string fid)
        {
            return ihd.HumanFileSelectSJXQ(fid);
        }
    }
}
