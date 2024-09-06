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
    public class ClassWeekdayConfiguration : IEntityTypeConfiguration<ClassWeekday>
    {
        public void Configure(EntityTypeBuilder<ClassWeekday> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartHour).IsRequired();
            builder.Property(x => x.EndHour).IsRequired();
            builder.HasOne(x => x.Weekday).WithMany(x => x.ClassWeekdays).HasForeignKey(x => x.WeekdayId);
            builder.HasOne(x => x.Class).WithMany(x => x.ClassWeekdays).HasForeignKey(x => x.ClassId);
        }
    }
}
