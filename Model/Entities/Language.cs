using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Level>? Levels { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
