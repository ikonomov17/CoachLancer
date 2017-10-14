using AutoMapper;
using CoachLancer.Services;
using CoachLancer.Web.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoachService coachService;
        private readonly IMapper mapper;

        public HomeController(ICoachService coachService, IMapper mapper)
        {
            this.coachService = coachService;
            this.mapper = mapper;
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
                .Select(c => this.mapper.Map<CoachThumbnailViewModel>(c))
                .ToList();

            return View(coaches);
        }
    }
}