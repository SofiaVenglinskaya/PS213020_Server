using PS213020_Server.BussinessLogic.Core.Models;
using PS213020_Server.DataAccess.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS213020_Server.BussinessLogic.AutoMapperProfile
{
    public class BussinessLogicProfile : Profile
    {
        public BussinessLogicProfile()
        {
            CreateMap<UserRto, UserInformationBlo>()
                .ForMember(a => a.Id, a => a.MapFrom(v => v.Id))
                .ForMember(a => a.IsBoy, a => a.MapFrom(v => v.IsBoy))
                .ForMember(a => a.FirstName, a => a.MapFrom(v => v.FirstName))
                .ForMember(a => a.LastName, a => a.MapFrom(v => v.LastName))
                .ForMember(a => a.Patronymic, a => a.MapFrom(v => v.Patronymic))
                .ForMember(a => a.AvatarUrl, a => a.MapFrom(v => v.AvatarUrl))
                .ForMember(a => a.Birthday, a => a.MapFrom(v => v.Birthday));

            CreateMap<UserRto, UserUpdateBlo>()
                .ForMember(a => a.Id, a => a.MapFrom(v => v.Id))
                .ForMember(a => a.IsBoy, a => a.MapFrom(v => v.IsBoy))
                .ForMember(a => a.FirstName, a => a.MapFrom(v => v.FirstName))
                .ForMember(a => a.LastName, a => a.MapFrom(v => v.LastName))
                .ForMember(a => a.Patronymic, a => a.MapFrom(v => v.Patronymic))
                .ForMember(a => a.AvatarUrl, a => a.MapFrom(v => v.AvatarUrl))
                .ForMember(a => a.Birthday, a => a.MapFrom(v => v.Birthday))
                .ForMember(a => a.Password, a => a.MapFrom(v => v.Password));
        }
          
    }
}
