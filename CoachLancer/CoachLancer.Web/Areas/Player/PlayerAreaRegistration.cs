using System.Web.Mvc;

namespace CoachLancer.Web.Areas.Player
{
    public class PlayerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Player";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;

            context.MapRoute(
                "Player_default",
                "Player/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}