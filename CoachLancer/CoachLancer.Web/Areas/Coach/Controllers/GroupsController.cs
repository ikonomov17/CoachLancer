using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class GroupsController : CoachController
    {
        // GET: Coach/Groups
        public ActionResult Index()
        {
            return View();
        }
    }
}