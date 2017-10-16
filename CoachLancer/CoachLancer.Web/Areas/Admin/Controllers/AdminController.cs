using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
    }
}