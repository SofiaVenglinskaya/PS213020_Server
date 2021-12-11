using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS213020_Server.BussinessLogic.Core.Interfaces;
using PS213020_Server.BussinessLogic.Core.Models;
using PS213020_Server.DataAccess.Core.Interface.Context;
using PS213020_Server.DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PS213020_Server.Shared.Exception;

namespace PS213020_Server.BussinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRubicContext _context;

        public UserService(IMapper mapper, IRubicContext context)
        {
            _mapper = mapper;
            this._context = context;
        }
        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="phoneNumberPrefix">Код страны телефона</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<UserInformationBlo> Auth(int phoneNumberPrefix, int phoneNumber, string password)
        {
           UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumberPrefix == phoneNumberPrefix && x.PhoneNumber == phoneNumber && x.Password == password);

            if (user == null)
                throw new NotFoundExceptions("Неверный логин или пароль");

            return await ConvertToUserInformationBlo(user);
            
        }
        /// <summary>
        /// Существует ли пользоваьель
        /// </summary>
        /// <param name="phoneNumberPrefix">Код страны номера телефона</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <returns></returns>
        public async Task<bool> DoesExist(int phoneNumberPrefix, int phoneNumber)
        {
            return await _context.Users.AnyAsync(x => x.PhoneNumberPrefix == phoneNumberPrefix && x.PhoneNumber == phoneNumber);
        }
        /// <summary>
        /// Возвращает пользователя
        /// </summary>
        /// <param name="UserId">ID</param>
        /// <returns></returns>
        public async Task<UserInformationBlo> Get(int UserId)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (user == null)
                throw new NotFoundExceptions("Не найден id");

            return await ConvertToUserInformationBlo(user);
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="phoneNumberPrefix">Код страны номера телефона</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<UserInformationBlo> Registration(int phoneNumberPrefix, int phoneNumber, string password)
        {
            UserRto newUser = new UserRto();
            newUser.PhoneNumberPrefix = phoneNumberPrefix;
            newUser.PhoneNumber = phoneNumber;
            newUser.Password = password;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return await ConvertToUserInformationBlo(newUser);


        }
        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="phoneNumberPrefix">Код страны номера телефона</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="password">Пароль</param>
        /// <param name="userUpdateBlo">Обновление</param>
        /// <returns></returns>
        public async Task<UserInformationBlo> Update(int phoneNumberPrefix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumberPrefix == phoneNumberPrefix && x.PhoneNumber == phoneNumber && x.Password == password);

            if (user == null)
                throw new NotFoundExceptions("Пользователь не найден");

            if (userUpdateBlo.IsBoy != null) user.IsBoy = userUpdateBlo.IsBoy;
            if (userUpdateBlo.Password != null) user.Password = userUpdateBlo.Password;
            if (userUpdateBlo.FirstName != null) user.FirstName = userUpdateBlo.FirstName;
            if (userUpdateBlo.LastName != null) user.LastName = userUpdateBlo.LastName;
            if (userUpdateBlo.Patronymic != null) user.Patronymic = userUpdateBlo.Patronymic;
            if (userUpdateBlo.Birthday != null) user.Birthday = userUpdateBlo.Birthday;
            if (userUpdateBlo.AvatarUrl != null) user.AvatarUrl = userUpdateBlo.AvatarUrl;

            await _context.SaveChangesAsync();
            return await ConvertToUserInformationBlo(user);
        }
        /// <summary>
        /// Конвертирует из UserRto в UserInformationBlo
        /// </summary>
        /// <param name="userRto"></param>
        /// <returns></returns>
        private async Task<UserInformationBlo> ConvertToUserInformationBlo(UserRto userRto)
        {
            
            if (userRto == null)
                throw new ArgumentNullException(nameof(userRto));

            UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);
            return userInformationBlo;
        }
    }
}
