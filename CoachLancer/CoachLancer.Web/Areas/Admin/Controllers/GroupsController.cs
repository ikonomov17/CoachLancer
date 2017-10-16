using AutoMapper;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Admin.Models.CoachViewModels;
using CoachLancer.Web.Areas.Admin.Models.GroupsViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Admin.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ISaveContext context;
        private readonly IGroupsService groupService;
        private readonly IMapper mapper;

        public GroupsController(IGroupsService groupService,
            ISaveContext context,
            IMapper mapper)
            
        {
            this.context = context;
            this.groupService = groupService;
            this.mapper = mapper;
        }
        // GET: Admin/Groups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var list = this.groupService.GetAll().Select(c => this.mapper.Map<GroupViewModel>(c)).ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
                var groupDetails = this.groupService.GetGroupById(id);
                var mappedGroup = this.mapper.Map<GroupViewModel>(groupDetails);

                return this.View(mappedGroup);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}