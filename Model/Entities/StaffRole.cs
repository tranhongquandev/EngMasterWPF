﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class StaffRole
    {
        public int Id { get; set; }

        public string? RoleName { get; set; }

        public int Rank { get; set; }

        public ICollection<Staff>? Staffs { get; set; }
    }
}
