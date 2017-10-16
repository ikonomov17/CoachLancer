using CoachLancer.Web.Areas.Coach.ViewModels;
using CoachLancer.Web.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoachLancer.Web.Areas.Admin.Models.GroupsViewModels
{
    public class GroupViewModel : IMapFrom<Data.Models.Groups>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TrainingsPerWeek { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}