﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class DashboardController : CoachController
    {
        // GET: Coach/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}