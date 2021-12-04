using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS213020_Server.DataAccess.Core.Models
{
    [Table("UserRole")]
    public class UserRto
    {
        [Key] public int Id { get; set; }
        [Required] public int PhoneNumberPrefix { get; set; }
        [Required] public int PhoneNumber { get; set; }
        [Required, MinLength(7)] public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsBoy { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public UserRoleRto Role { get; set; }

        [NotMapped]
        public string GetFullName
        {
            get => LastName + " " + FirstName + " " + Patronymic;
        }
    }
}
