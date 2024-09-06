using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public Teacher? Teacher { get; set; }

        public Course? Course { get; set; }

        public ICollection<ClassWeekday>? ClassWeekdays { get; set; }

        public ICollection<ClassStudent>? ClassStudents { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }


}










