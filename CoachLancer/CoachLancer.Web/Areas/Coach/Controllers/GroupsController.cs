using AutoMapper;
using CoachLancer.Data.Models;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Coach.ViewModels;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class GroupsController : CoachController
    {
        private readonly IMapper mapper;
        private readonly ICoachService coachService;
        private readonly IGroupsService groupsService;
        private readonly IPlayersService playersService;

        public GroupsController(
            ICoachService coachService,
            IGroupsService groupsService,
            IPlayersService playersService,
            IMapper mapper
            )
        {
            this.coachService = coachService;
            this.groupsService = groupsService;
            this.playersService = playersService;
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

        [HttpPost]
        public JavaScriptResult AddPlayer(int groupId, string playerUsername)
        {
            var player = this.playersService.GetPlayerByUsername(playerUsername);
            var group = this.groupsService.GetGroupById(groupId);
            player.Groups.Add(group);
            this.playersService.UpdatePlayer(player);

            return JavaScript("location.reload(true)");
        }

        [HttpPost]
        public JsonResult GetGroupsData(IDataTablesRequest request)
        {
            if (this.Request.IsAjaxRequest() && request.Search.Value != null)
            {
                var wholeDataCount = this.groupsService.GetAll().Count();
                var filteredData = this.groupsService.GetGroupsByName(request.Search.Value);

                // Paging filtered data.
                // Paging is rather manual due to in-memmory (IEnumerable) data.
                var dataPage = filteredData.Skip(request.Start).Take(request.Length);

                // Response creation. To create your response you need to reference your request, to avoid
                // request/response tampering and to ensure response will be correctly created.
                var response = DataTablesResponse.Create(request, wholeDataCount, filteredData.Count(), dataPage);

                // Easier way is to return a new 'DataTablesJsonResult', which will automatically convert your
                // response to a json-compatible content, so DataTables can read it when received.
                return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
            }
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);
            var groups = coach.Groups.Select(g => this.mapper.Map<GroupViewModel>(g)).ToList();
            var sDataPage = groups.Skip(request.Start).Take(request.Length);
            var sResponse = DataTablesResponse.Create(request, groups.Count, groups.Count, sDataPage);
            return new DataTablesJsonResult(sResponse, JsonRequestBehavior.AllowGet);
        }
    }
}