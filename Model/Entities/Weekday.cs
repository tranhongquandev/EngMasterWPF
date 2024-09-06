using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Weekday
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<ClassWeekday>? ClassWeekdays { get; set; }
    }
}
