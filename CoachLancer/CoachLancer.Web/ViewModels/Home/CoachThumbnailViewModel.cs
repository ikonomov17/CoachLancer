using CoachLancer.Services.Models;
using System;

namespace CoachLancer.Web.ViewModels.Home
{
    public class CoachThumbnailViewModel
    {
        public CoachThumbnailViewModel()
        {

        }

        public CoachThumbnailViewModel(CoachModel coach)
        {
            this.Username = coach.Username;
        }

        public string Username { get; set; }

        public DateTime? UserSince { get; set; }
    }
}