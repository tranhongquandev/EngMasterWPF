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
            builder.Property(c => c.Term).HasMaxLength(50);
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.Language).WithMany(l => l.Courses).HasForeignKey(c => c.LanguageId);
            builder.HasOne(c => c.Level).WithMany(l => l.Courses).HasForeignKey(c => c.LevelId);
            builder.HasOne(c => c.Category).WithMany(c => c.Courses).HasForeignKey(c => c.CategoryId);
            builder.HasIndex(c => c.Code);
            builder.HasIndex(c => c.Name);
            builder.HasIndex(c => c.Term);

        }
    }
}
