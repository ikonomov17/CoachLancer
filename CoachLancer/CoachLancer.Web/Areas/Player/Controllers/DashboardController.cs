using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player.Controllers
{
    public class DashboardController : PlayerController
    {
        // GET: Player/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}