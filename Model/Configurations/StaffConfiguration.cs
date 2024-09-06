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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(150);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.BirthDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.State).HasMaxLength(50);
            
            builder.HasOne(x => x.StaffAccount).WithOne(x => x.Staff).HasForeignKey<StaffAccount>(x => x.StaffId);

            builder.HasData(new
            {
                Id = 1,
                FirstName = "Quản trị",
                LastName = "viên",
                Email = "engmaster.admin@gmail.com",
                Phone = "0123456789",
                Address = "123 Đường ABC",
                City = "Hồ Chí Minh",
                State = "Việt Nam",
                StaffRoleId = 1

            });
        }
    }
}
