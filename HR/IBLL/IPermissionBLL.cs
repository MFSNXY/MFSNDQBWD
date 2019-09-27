using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IPermissionBLL
    {

        int PermissionAdd(PermissionModel p);

        int PermissionUpdate(PermissionModel p);

        int PermissionDelete(int id);

        PermissionModel PermissionBy(int id);

        List<PermissionModel> PermissionSelect();

        List<PermissionModel> PermissionFY(int currentPage, int pageSize, out int rows);

        List<PermissionModel> PermissionRole(int pid, int rid);
    }
}
