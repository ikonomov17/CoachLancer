using CoachLance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoachLancer.Services.Models
{
    public class CoachModel
    {
        public CoachModel()
        {

        }

        public CoachModel(Coach coach)
        {
            if (coach != null)
            {
                this.Username = coach.UserName;
                this.FirstName = coach.FirstName;
                this.LastName = coach.LastName;
                this.DateOfBirth = coach.DateOfBirth;
                //this.Age = SetAge(coach.DateOfBirth);
                //this.Gender = coach.GenderId;
                this.Location = coach.Location;
                //this.Languages = coach.Languages;
                this.Nationality = coach.Nationality;
                this.AboutMe = coach.AboutMe;
                this.PricePerHourTraining = coach.PricePerHourTraining;
                this.StartedCoaching = coach.StartedCoaching;
                //this.Licenses = coach.Licenses;
                this.UserSince = coach.CreatedOn;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        //public Gender Gender { get; set; }

        public string Location { get; set; }

        //public ICollection<string> Languages { get; set; }

        public string Nationality { get; set; }

        public string AboutMe { get; set; }

        public double PricePerHourTraining { get; set; }

        public DateTime? StartedCoaching { get; set; }

        //public ICollection<string> Licenses { get; set; }

        public DateTime? UserSince { get; set; }

        public static Expression<Func<Coach, CoachModel>> Create
        {
            get
            {
                return c => new CoachModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Username = c.UserName,
                    DateOfBirth = c.DateOfBirth,
                    //Age = SetAge(c.DateOfBirth),
                    Location = c.Location,
                    //Languages = c.Languages,
                    Nationality = c.Nationality,
                    AboutMe = c.AboutMe,
                    PricePerHourTraining = c.PricePerHourTraining,
                    StartedCoaching = c.StartedCoaching,
                    //Licenses = c.Licenses,
                    UserSince = c.CreatedOn
                };
            }
        }

        //private static int SetAge(DateTime? dateOfBirth)
        //{
        //    if (dateOfBirth.HasValue)
        //    {
        //        var currentDate = DateTime.UtcNow;
        //        var inputDate = dateOfBirth.Value;
        //        var age = currentDate.Year - inputDate.Year;
        //        if (currentDate.Month <= inputDate.Month)
        //        {
        //            if (currentDate.Day < inputDate.Day)
        //            {
        //                age--;
        //            }
        //        }
        //        return age;
        //    }
        //    return 0;
        //}

    }
}
