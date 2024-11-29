
using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class ClassDTO : ViewModelBase
    {

        public int Id { get; set; }

        public string? ClassCode { get; set; }

        public string? ClassName { get; set; }

        public string? TeacherId { get; set; }

        public string? FullName { get; set; }

        public string? CourseId { get; set; }

        public string? CourseName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }
}
