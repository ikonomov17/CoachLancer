using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class ProfileController : CoachController
    {
        public ProfileController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}