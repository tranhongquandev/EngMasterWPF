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

        public string? MethodName { get; set; }

        public ICollection<Payment>? Payment { get; set; }
    }
}
