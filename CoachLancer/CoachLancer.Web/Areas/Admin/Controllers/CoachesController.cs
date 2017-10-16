using AutoMapper;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Contracts;
using CoachLancer.Web.Areas.Admin.Models.CoachViewModels;
using CoachLancer.Web.Auth.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Admin.Controllers
{
    public class CoachesController : Controller
    {
        private readonly ISaveContext context;
        private readonly ICoachService coachService;
        private readonly IMapper mapper;
        private readonly IUserService userManager;

        public CoachesController(
            ICoachService coachService,
            ISaveContext context, 
            IMapper mapper,
            IUserService userManager)
        {
            this.context = context;
            this.coachService = coachService;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        // GET: Admin/Coaches
        public ActionResult Index()
        {
            var list = this.coachService.GetAll().Select(c => this.mapper.Map<CoachTableViewModel>(c)).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}