using AutoMapper;
using PS213020_Server.BussinessLogic.Core.Interfaces;
using PS213020_Server.BussinessLogic.Core.Models;
using PS213020_Server.DataAccess.Core.Interface.Context;
using PS213020_Server.DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PS213020_Server.BussinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRubicContext context;

        public UserService(IMapper mapper, IRubicContext context)
        {
            _mapper = mapper;
            this.context = context;
        }

        public Task<UserInformationBlo> Auth(int phoneNumberPrefix, int phoneNumber, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesExist(int phoneNumberPrefix, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Get(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Registration(int phoneNumberPrefix, int phoneNumber, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Update(int phoneNumberPrefix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo)
        {
            throw new NotImplementedException();
        }

        private async Task<UserInformationBlo> ConvertToUserInformationBlo(UserRto userRto)
        {
            
            if (userRto == null)
                throw new ArgumentNullException(nameof(userRto));

            UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);
            return userInformationBlo;
        }
    }
}
