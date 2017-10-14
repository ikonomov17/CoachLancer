using AutoMapper;
using CoachLancer.Data.Models;
using CoachLancer.Web.Infrastructure;
using System;

namespace CoachLancer.Web.ViewModels.Home
{
    public class CoachThumbnailViewModel : IMapFrom<Coach>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public DateTime? UserSince { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Coach, CoachThumbnailViewModel>()
                .ForMember(coachThumbnail => coachThumbnail.UserSince, cfg => cfg.MapFrom(coach => coach.CreatedOn))
                .ForMember(cThumb => cThumb.Username, cfg => cfg.MapFrom(c => c.UserName));
        }
    }
}