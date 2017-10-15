using CoachLancer.Data.Models;
using CoachLancer.Services;
using CoachLancer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Coach.Controllers
{
    public class GroupsController : CoachController
    {
        private readonly ICoachService coachService;
        private readonly IGroupsService groupsService;

        public GroupsController(ICoachService coachService, IGroupsService groupsService)
        {
            this.coachService = coachService;
            this.groupsService = groupsService;
        }

        // GET: Coach/Groups
        public ActionResult Index()
        {
            var coach = this.coachService.GetCoachByUsername(this.User.Identity.Name);

            return View(coach.Groups);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Groups model)
        {
            this.groupsService.CreateGroup(model);
            this.coachService.AddGroupToCoach(this.User.Identity.Name, model);
            return RedirectToAction("Index");
        }
    }
}