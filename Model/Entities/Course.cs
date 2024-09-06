using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Course
    {
        public int Id { get; set; }

       public string? Code { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Term { get; set; }

        
        public int LanguageId { get; set; }

        public int LevelId { get; set; }

        public int CategoryId { get; set; }

        public Language? Language { get; set; }
        public Level? Level { get; set; }
        public Category? Category { get; set; }

        public ICollection<Class> Classes { get; set; }

    }
}
