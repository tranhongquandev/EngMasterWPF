using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class UserRoles
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Rank { get; set; }

        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
