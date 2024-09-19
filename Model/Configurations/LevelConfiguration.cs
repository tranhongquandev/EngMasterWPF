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
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LevelCode).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LevelName).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Language).WithMany(x => x.Level).HasForeignKey(x => x.LanguageId);
        }
    }
}
