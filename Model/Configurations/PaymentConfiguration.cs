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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).IsRequired().HasDefaultValue(0).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PaymentDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.PaymentCode).IsRequired();

            builder.HasOne(x => x.PaymentMethod).WithMany(x => x.Payments).HasForeignKey(x => x.PaymentMethodId);
            builder.HasOne(x => x.Class).WithMany(x => x.Payments).HasForeignKey(x => x.ClassId);
            builder.HasOne(x => x.UserAccounts).WithMany(x => x.Payments).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Status).WithOne(x => x.Payments).HasForeignKey<Payment>(x => x.PaymentStatusId);
        }
    }
}
