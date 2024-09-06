using EngMasterWPF.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Configurations
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
                new
                {
                    Id = 1,
                    Name = "Thanh toán tiền mặt"
                },
                new
                {
                    Id = 2,
                    Name = "Chuyển khoản ngân hàng"
                }, 
                new
                {
                    Id = 3,
                    Name = "Thẻ VISA"
                }, 
                new
                {
                    Id = 4,
                    Name = "Ví điện tử"
                }

                );
        }
    }
}
