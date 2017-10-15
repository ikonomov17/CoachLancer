using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerController : Controller
    {
    }
}