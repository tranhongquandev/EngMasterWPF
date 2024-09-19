﻿using EngMasterWPF.Model.Entities;
using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngMasterWPF.DTOs
{
    public class StudentDTO : BaseViewModel
    {

        public int Id { get; set; }

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string? Status { get; set; }



    }
}
