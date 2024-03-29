﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IEngageInterviewDAO
    {
        int EngageInterviewAdd(EngageInterviewModel p);

        int EngageInterviewUpdate(EngageInterviewModel p);

        int EngageInterviewDelete(int id);

        EngageInterviewModel EngageInterviewBy(int id);

        List<EngageInterviewModel> EngageInterviewSelect();

        EngageInterviewModel EngageInterviewSelectResumeId(int rid);

        List<EngageInterviewModel> EngageInterviewFY(int currentPage, int pageSize, out int rows);

        List<EngageInterviewModel> EngageInterviewMSSX(int currentPage, int pageSize, out int rows);
    }
}
