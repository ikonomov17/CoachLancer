using CoachLancer.Services;
using CoachLancer.Web.Areas.Coach.ViewModels;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class ProfileController : CoachController
    {
        private readonly ICoachService coachService;
        public ProfileController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public ActionResult Index()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var viewModel = new ProfileViewModel(coach);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var viewModel = new ProfileViewModel(coach);
            return PartialView(viewModel);
        }
    }
}