using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int RoleId { get; set; }

        public string? Sex { get; set; }

        public string? Email { get; set; }
        
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? HireAt { get; set; } 

        public string? Status { get; set; }

        public ICollection<UserClass>? UserClasses { get; set; }

        public UserAccounts? UserAccounts { get; set; }

        public UserRoles? UserRoles { get; set; }


    }
}
