using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class ClassWeekday
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int WeekdayId { get; set; }

        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }

        public Class? Class { get; set; }

        public Weekday? Weekday { get; set; }
    }
}
