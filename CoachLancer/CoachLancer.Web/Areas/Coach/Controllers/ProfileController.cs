using AutoMapper;
using CoachLancer.Services;
using CoachLancer.Services.Models;
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
            var coachModel = this.mapper.Map<CoachModel>(model);

            //this.coachService.UpdateCoach(coachModel);
            return RedirectToAction("Index");
        }
    }
}