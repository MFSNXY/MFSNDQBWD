﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HR
{
    public class MyHub1 : Hub
    {
        public void Chima(string name,string msg)
        {
            Clients.Others.HSTT(name,msg);
        }
    }
}