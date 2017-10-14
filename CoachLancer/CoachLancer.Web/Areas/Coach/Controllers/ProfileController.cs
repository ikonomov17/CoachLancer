using AutoMapper;
using CoachLancer.Services;
using CoachLancer.Web.Areas.Coach.ViewModels;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class ProfileController : CoachController
    {
        private readonly ICoachService coachService;
        private readonly IMapper mapper;

        public ProfileController(ICoachService coachService, IMapper mapper)
        {
            this.coachService = coachService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var viewModel = this.mapper.Map<ProfileViewModel>(coach);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var viewModel = this.mapper.Map<ProfileViewModel>(coach);
            return PartialView(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProfileViewModel model)
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            coach.FirstName = model.FirstName;
            coach.LastName = model.LastName;
            coach.Email = model.Email;
            coach.PricePerHourTraining = model.PricePerHourTraining;
            coach.Location = model.Location;

            this.coachService.UpdateCoach(coach);

            return PartialView("_ProfilePartial", this.mapper.Map<ProfileViewModel>(coach));
        }
    }
}