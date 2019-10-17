using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using IBLL;
using IDAO;
using Model;
using DAO;

namespace BLL
{
    public class PermissionBLL : IPermissionBLL
    {

        IPermissionDAO ipd = IocCreate.CreateDao<IPermissionDAO, PermissionDAO>();
        public int PermissionAdd(PermissionModel p)
        {
            return ipd.PermissionAdd(p);
        }

        public PermissionModel PermissionBy(int id)
        {
            return ipd.PermissionBy(id);
        }

        public int PermissionDelete(int id)
        {
            return ipd.PermissionDelete(id);
        }

        public List<PermissionModel> PermissionFY(int currentPage, int pageSize, out int rows)
        {
            return ipd.PermissionFY(currentPage, pageSize,out rows);
        }

        public List<PermissionModel> PermissionRole(int pid, int rid)
        {
            return ipd.PermissionRole(pid, rid);
        }

        public List<PermissionModel> PermissionSelect()
        {
            return ipd.PermissionSelect();
        }

        public int PermissionUpdate(PermissionModel p)
        {
            return ipd.PermissionUpdate(p);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocContainer;
using IBLL;
using IDAO;
using Model;
using DAO;

namespace BLL
{
    public class PermissionBLL : IPermissionBLL
    {

        IPermissionDAO ipd = IocCreate.CreateDao<IPermissionDAO, PermissionDAO>();
        public int PermissionAdd(PermissionModel p)
        {
            return ipd.PermissionAdd(p);
        }

        public PermissionModel PermissionBy(int id)
        {
            return ipd.PermissionBy(id);
        }

        public int PermissionDelete(int id)
        {
            return ipd.PermissionDelete(id);
        }

        public List<PermissionModel> PermissionFY(int currentPage, int pageSize, out int rows)
        {
            return ipd.PermissionFY(currentPage, pageSize,out rows);
        }

        public List<PermissionModel> PermissionRole(int pid, int rid)
        {
            return ipd.PermissionRole(pid, rid);
        }

        public List<PermissionModel> PermissionSelect()
        {
            return ipd.PermissionSelect();
        }

        public int PermissionUpdate(PermissionModel p)
        {
            return ipd.PermissionUpdate(p);
        }
        public List<PermissionModel> PermissionSelectPid(int pid)
        {
            return ipd.PermissionSelectPid(pid);
        }
        public List<PermissionModel> qx(int c, int d)
        {
            return ipd.qx(c, d);
        }
    }
}
