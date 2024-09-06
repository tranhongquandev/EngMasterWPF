using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Staff
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public DateTime? BirthDate { get; set; }

        public int StaffRoleId { get; set; }

        public StaffAccount? StaffAccount { get; set; }

        public StaffRoles? StaffRoles { get; set; }
    }
}
