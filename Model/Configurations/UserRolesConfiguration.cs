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
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Rank).IsRequired();
            builder.HasData
                (
                new UserRoles { Id = 1, Name = "Admin", Rank = 1 },
                new UserRoles { Id = 2, Name = "Staff", Rank = 2 },
                new UserRoles { Id = 3, Name = "Teacher", Rank = 3 },
                new UserRoles { Id = 4, Name = "Student", Rank = 4 }
                );
        }
    }
}
