﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface IPermissionDAO
    {
        int PermissionAdd(PermissionModel p);

        int PermissionUpdate(PermissionModel p);

        int PermissionDelete(int id);

        PermissionModel PermissionBy(int id);

        List<PermissionModel> PermissionSelect();

        List<PermissionModel> PermissionFY(int currentPage, int pageSize, out int rows);


        List<PermissionModel> PermissionRole(int pid, int rid);

        List<PermissionModel> PermissionSelectPid(int pid);
        List<QxModel> qx(int c, int d);

        List<PermissionModel> PermissionRole();

    }
}
