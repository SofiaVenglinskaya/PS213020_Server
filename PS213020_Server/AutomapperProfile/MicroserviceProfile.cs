using AutoMapper;
using PS213020_Server.BussinessLogic.Core.Models;
using PS213020_Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS213020_Server.AutomapperProfile
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile()
        {
            CreateMap<UserInformationBlo, UserInformationDto>();
        }
    }
}
