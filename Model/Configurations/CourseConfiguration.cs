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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired().HasDefaultValue(GenerateRandomCode());
            builder.HasOne(c => c.Language).WithMany(l => l.Courses).HasForeignKey(c => c.LanguageId);
           
            builder.HasIndex(c => c.Code);
            builder.HasIndex(c => c.Name);

            builder.HasData(
                new Course {Id = 1, Name = "English for Beginners", Description = "Basic English course for beginners.", LanguageId = 1},
                    new Course {Id = 2, Name = "Intermediate English", Description = "For learners who have some experience.", LanguageId = 1},
                    new Course {Id = 3, Name = "Advanced English", Description = "Advanced course for experienced learners.", LanguageId = 1},
                    new Course {Id = 4, Name = "Business English", Description = "Specialized course for business professionals.", LanguageId = 1},
                    new Course {Id = 5, Name = "English for Travel", Description = "English course designed for travelers.", LanguageId = 1 }
                );


            



        }
        private static string GenerateRandomCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
