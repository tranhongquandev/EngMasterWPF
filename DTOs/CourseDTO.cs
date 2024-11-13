
using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class CourseDTO : ViewModelBase
    {

        public int Id { get; set; }

        public string? CourseCode { get; set; }

        public string? Description { get; set; }

        public string? CourseName { get; set; }

        public string? Duration { get; set; }

        public int? Fee { get; set; }
        public decimal? Discount { get; set; }


        public decimal? TotalFee { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool? IsActive { get; set; }

        public int? LevelId { get; set; }

    }
}
