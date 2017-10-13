using CoachLancer.Services;
using CoachLancer.Web.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoachService coachService;

        public HomeController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Explore()
        {

            var coaches = this.coachService.GetLastRegisteredCoaches(10)
                .Select(c => new CoachThumbnailViewModel(c))
                .ToList();

            return View(coaches);
        }
    }
}