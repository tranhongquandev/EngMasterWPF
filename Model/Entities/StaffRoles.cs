using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class StaffRoles
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Rank { get; set; }

        public ICollection<Staff>? Staffs { get; set; }
    }
}
