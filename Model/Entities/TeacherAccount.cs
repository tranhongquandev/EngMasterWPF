using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class TeacherAccount
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public int TeacherId { get; set; }

        public Boolean isActive { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
