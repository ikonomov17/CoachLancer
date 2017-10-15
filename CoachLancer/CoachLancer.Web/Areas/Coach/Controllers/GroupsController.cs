using AutoMapper;
using CoachLancer.Data.Models;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Coach.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class GroupsController : CoachController
    {
        private readonly IMapper mapper;
        private readonly ICoachService coachService;
        private readonly IGroupsService groupsService;

        public GroupsController(
            ICoachService coachService, 
            IGroupsService groupsService,
            IMapper mapper
            )
        {
            this.coachService = coachService;
            this.groupsService = groupsService;
            this.mapper = mapper;
        }

        // GET: Coach/Groups
        public ActionResult Index()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var groups = coach.Groups.Select(g => this.mapper.Map<GroupViewModel>(g)).ToList();
            return View(groups);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateGroupViewModel viewModel)
        {
            var model = this.mapper.Map<Groups>(viewModel);
            this.groupsService.CreateGroup(model);
            this.coachService.AddGroupToCoach(this.User.Identity.Name, model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (this.coachService.GroupBelongsToCoach(this.User.Identity.Name, id))
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
    }
}