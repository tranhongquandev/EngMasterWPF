using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentCode { get; set; }

        public decimal Amount { get; set; }

        public int PaymentStatusId { get; set; }

        public int PaymentMethodId { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public PaymentStatus? Status { get; set; }

        public Student? Student { get; set; }

        public Class? Class { get; set; }
    }
}
