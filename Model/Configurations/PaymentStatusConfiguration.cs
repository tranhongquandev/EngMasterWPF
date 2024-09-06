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
    public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StatusName).IsRequired().HasMaxLength(100);

            builder.HasData(
                new{
                    Id = 1,
                    StatusName = "Created"
                },
                new
                {
                    Id = 2,
                    StatusName = "Pending"
                },
                new
                 {
                     Id = 3,
                     StatusName = "Success"
                 },
                new
                {
                    Id = 4,
                    StatusName = "Cancel"
                }



                );
        }
    }
}
