using System;
using System.Collections.Generic;
using System.Text;

namespace PS213020_Server.BussinessLogic.Core.Models
{
    public class UserUpdateBlo
    {
        public int Id { get; set; }
        public bool IsBoy { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string AvatarUrl { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
