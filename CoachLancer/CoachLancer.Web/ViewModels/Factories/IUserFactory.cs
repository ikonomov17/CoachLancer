using CoachLance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachLancer.Web.ViewModels.Factories
{
    public interface IUserFactory
    {
        User CreateUserByRole(string role);
    }
}