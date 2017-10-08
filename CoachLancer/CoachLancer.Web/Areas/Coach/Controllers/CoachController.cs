using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    [Authorize(Roles = "Coach")]
    public class CoachController : Controller
    {
    }
}