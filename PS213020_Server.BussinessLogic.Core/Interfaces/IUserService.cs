using PS213020_Server.BussinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PS213020_Server.BussinessLogic.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserInformationBlo> Auth(int phoneNumberPrefix, int phoneNumber, string password);
        Task<UserInformationBlo> Registration(int phoneNumberPrefix, int phoneNumber, string password);
        Task<UserInformationBlo> Get(int UserId);
        Task<UserInformationBlo> Update(int phoneNumberPrefix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo);
        Task<bool> DoesExist(int phoneNumberPrefix, int phoneNumber);
    }
}
