using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }

        public string? StatusName { get; set; }

        public Payment? Payments { get; set; }
    }
}
