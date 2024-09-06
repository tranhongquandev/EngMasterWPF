﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }
}
