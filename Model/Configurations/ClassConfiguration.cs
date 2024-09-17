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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Price).HasDefaultValue(0).HasColumnType("decimal(18,2)");
      
            builder.HasOne(x => x.Course).WithMany(x => x.Classes).HasForeignKey(x => x.CourseId);

            builder.HasData(
                 new Class
                 {
                     Id = 1,
                     Name = "Class A",
                     Description = "Lớp học tiếng Anh A",
                     CourseId = 1,
                     Price = 100000000,
                     StartDate = new DateTime(2024, 9, 1, 9, 0, 0),
                     EndDate = new DateTime(2024, 9, 1, 12, 0, 0)
                 },
                    new Class
                    {
                        Id = 2,
                        Name = "Class B",
                        Description = "Lớp học tiếng Anh B",
                        CourseId = 5,
                        Price = 2000000,
                        StartDate = new DateTime(2024, 9, 2, 9, 0, 0),
                        EndDate = new DateTime(2024, 9, 2, 12, 0, 0)
                    },
                    new Class
                    {
                        Id = 3,
                        Name = "Class C",
                        Description = "Lớp học tiếng Anh C",
                        CourseId = 3,
                        Price = 3000000,
                        StartDate = new DateTime(2024, 9, 3, 9, 0, 0),
                        EndDate = new DateTime(2024, 9, 3, 12, 0, 0)
                    },
                    new Class
                    {
                        Id = 4,
                        Name = "Class D",
                        Description = "Lớp học tiếng Anh D",
                        CourseId = 5,
                        Price = 4000000,
                        StartDate = new DateTime(2024, 9, 4, 9, 0, 0),
                        EndDate = new DateTime(2024, 9, 4, 12, 0, 0)
                    },
                    new Class
                    {
                        Id = 5,
                        Name = "Class E",
                        Description = "Lớp học tiếng Anh E",
                        CourseId = 4,
                        Price = 5000000,
                        StartDate = new DateTime(2024, 9, 5, 9, 0, 0),
                        EndDate = new DateTime(2024, 9, 5, 12, 0, 0)
                    }
                );
            
        }
    }
}
