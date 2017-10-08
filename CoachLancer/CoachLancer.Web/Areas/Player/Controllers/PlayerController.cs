using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerController : Controller
    {
    }
}