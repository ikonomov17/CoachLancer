using CoachLancer.Data.Models;
using CoachLancer.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Areas.Coach.ViewModels
{
    public class CreateGroupViewModel : IMapFrom<Groups>
    {
        [Required]
        [StringLength(100, ErrorMessage = "Group name should be between 2 and 100 symbols", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Trainings per week", Description = "Trainings per week")]
        [Range(1,14,ErrorMessage = "Training should be between 1 and 14")]
        public int TrainingsPerWeek { get; set; }
    }
}