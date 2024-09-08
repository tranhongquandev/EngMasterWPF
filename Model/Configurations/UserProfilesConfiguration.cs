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
    public class UserProfilesConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(120);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.BirthDate);

            builder.HasData
                (
                
                    new UserProfile
                    {
                        Id = 1,
                        FirstName = "Quản trị",
                        LastName = "viên",
                        Email = "engmaster.admin@gmail.com",
                        Phone = 0123456789,
                        Address = "123 Đường ABC",
                        City = "Hà Nội",
                        State = "Việt Nam",

                    }
                );

        }
    }
}
