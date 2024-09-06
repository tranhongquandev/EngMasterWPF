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
    public class StaffRolesConfiguration : IEntityTypeConfiguration<StaffRoles>
    {
        public void Configure(EntityTypeBuilder<StaffRoles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Rank).IsRequired().HasMaxLength(50);
            builder.HasData(
            new
            {
                Id = 1,
                Name = "Admin",
                Rank = 1
            }
            );
        }
    }
}
