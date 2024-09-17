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
        

        
        public int LanguageId { get; set; }

        public Language? Language { get; set; }
        
        public ICollection<Class>? Classes { get; set; }

    }
}
