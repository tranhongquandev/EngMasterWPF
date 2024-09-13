using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class StudentDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirtDay { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public string? Status { get; set; }

    }
}
