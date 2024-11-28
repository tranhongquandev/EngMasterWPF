﻿
using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class TeacherDTO : ViewModelBase
    {

        public int Id { get; set; }

        public string? TeacherCode { get; set; }

        public string? ImgUrl { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? DateOfBirth { get; set; }

        public string? HireDate { get; set; }

        public string? EndDate { get; set; }

        public bool? IsActive { get; set; }



    }
}
