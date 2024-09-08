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
            
        }
    }
}
