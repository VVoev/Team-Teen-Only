﻿using StupidChessBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StupidChessBase.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db  = new ApplicationDbContext();


    }
}