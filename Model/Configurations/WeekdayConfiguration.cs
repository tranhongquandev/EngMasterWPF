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
    public class WeekdayConfiguration : IEntityTypeConfiguration<Weekday>
    {
        public void Configure(EntityTypeBuilder<Weekday> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.DayName).HasMaxLength(50);
        }
    }
}
