using AutoMapper;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Player.ViewModels;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player.Controllers
{
    public class ProfileController : PlayerController
    {
        private readonly IPlayersService playerService;
        private readonly IMapper mapper;
        private readonly ISaveContext saveContext;

        public ProfileController(PlayersService playerService, ISaveContext saveContext, IMapper mapper)
        {
            this.playerService = playerService;
            this.saveContext = saveContext;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var player = this.playerService.GetPlayerByUsername(this.User.Identity.Name);
            var viewModel = this.mapper.Map<ProfileViewModel>(player);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var player = this.playerService.GetPlayerByUsername(this.User.Identity.Name);
            var viewModel = this.mapper.Map<ProfileViewModel>(player);
            return PartialView(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProfileViewModel model)
        {
            var player = this.playerService.GetPlayerByUsername(this.User.Identity.Name);
            player.FirstName = model.FirstName;
            player.LastName = model.LastName;
            player.Email = model.Email;
            player.Location = model.Location;
            player.DateOfBirth = model.DateOfBirth;
            this.playerService.UpdatePlayer(player);
            this.saveContext.Commit();

            return PartialView("_ProfilePartial", this.mapper.Map<ProfileViewModel>(player));
        }
    }
}