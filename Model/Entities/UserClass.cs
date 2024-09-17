using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class UserClass
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public Class? Class { get; set; }
        public UserProfile? UserProfiles { get; set; }
    }
}
