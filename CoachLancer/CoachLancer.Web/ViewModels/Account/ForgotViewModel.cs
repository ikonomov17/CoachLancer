﻿using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
