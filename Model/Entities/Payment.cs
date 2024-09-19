﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public string? PaymentCode { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentStatus { get; set; }

        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public double Amount { get; set; }

    }
}
