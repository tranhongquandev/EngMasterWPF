using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class UserAccounts
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        public Boolean IsActive { get; set; } 

        public int UserProfileId { get; set; }

        public int UserRoleId { get; set; }

        public UserRoles? UserRoles { get; set; }

        public UserProfile? UserProfile { get; set; }

        public ICollection<Payment>? Payments { get; set; }

        public ICollection<UserClass>? UserClasses { get; set; }

        public ICollection<Class>? Classes { get; set; }
    }
}
