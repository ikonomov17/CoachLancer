using CoachLancer.Services;
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var coaches = this.coachService.GetAll();

            return View();
        }
    }
}