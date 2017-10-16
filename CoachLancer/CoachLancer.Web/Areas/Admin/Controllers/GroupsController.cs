using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Admin.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Admin/Groups
        public ActionResult Index()
        {
            return View();
        }

    }
}