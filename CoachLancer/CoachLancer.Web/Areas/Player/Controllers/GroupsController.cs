using AutoMapper;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Player.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPlayersService playersService;
        private readonly IGroupsService groupsService;

        public GroupsController(
            IPlayersService playersService,
            IGroupsService groupsService,
            IMapper mapper
        )
        {
            this.playersService = playersService;
            this.groupsService = groupsService;
            this.mapper = mapper;
        }

        // GET: Coach/Groups
        public ActionResult Index()
        {
            var player = this.playersService.GetPlayerByUsername(this.User.Identity.Name);
            var groups = player.Groups.Select(g => this.mapper.Map<GroupViewModel>(g)).ToList();
            return View(groups);
        }

        public ActionResult Details(int id)
        {
            if (this.playersService.PlayerBelongsToGroup(this.User.Identity.Name, id))
            {
                var groupDetails = this.groupsService.GetGroupById(id);
                var mappedGroup = this.mapper.Map<GroupViewModel>(groupDetails);

                return this.View(mappedGroup);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult LeaveGroup(int groupId)
        {
            var player = this.playersService.GetPlayerByUsername(this.HttpContext.User.Identity.Name);
            var group = player.Groups.FirstOrDefault(x => x.Id == groupId);
            player.Groups.Remove(group);

            this.playersService.UpdatePlayer(player);
            return RedirectToAction("Index");
        }

        //public ActionResult Explore()
        //{
            
        //}
    }
}