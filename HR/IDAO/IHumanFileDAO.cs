﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IHumanFileDAO
    {
        int HumanFileAdd(HumanFileModel p);

        int HumanFileUpdate(HumanFileModel p);

        int HumanFileDelete(int id);

        HumanFileModel HumanFileBy(int id);

        List<HumanFileModel> HumanFileSelect();

        List<HumanFileModel> HumanFileFY(int currentPage, int pageSize, out int rows);

        int HumanFileSetPic(string hfid, string pic);

        List<HumanFileModel> HumanFileCheckList(int currentPage, int pageSize, out int rows);
    }
}
