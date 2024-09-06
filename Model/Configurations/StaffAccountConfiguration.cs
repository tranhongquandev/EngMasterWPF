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
    public class StaffAccountConfiguration : IEntityTypeConfiguration<StaffAccount>
    {
        public void Configure(EntityTypeBuilder<StaffAccount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.isActive).IsRequired().HasDefaultValue(true);
            builder.HasData(new
            {
                Id = 1,
                Username = "engmaster.admin",
                Password = "1234567890@aA",
                StaffId = 1,
                isActive = true,
            });
        }
    }
}
