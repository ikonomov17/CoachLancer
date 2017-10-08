using CoachLance.Data.Models;

namespace CoachLancer.Web.ViewModels.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUserByRole(string role)
        {
            switch (role.ToLower())
            {
                case "coach":
                    return new Coach();
                case "player":
                    return new Player();
                default:
                    return null;
            }
        }
    }
}