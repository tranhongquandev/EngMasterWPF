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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Name);
            builder.HasData(
                new Language { Id = 1, Name = "Tiếng Anh" },
                new Language { Id = 2, Name = "Tiếng Pháp" },
                new Language { Id = 3, Name = "Tiếng Tây Ban Nha" },
                new Language { Id = 4, Name = "Tiếng Trung" },
                new Language { Id = 5, Name = "Tiếng Nhật"}
                );
        }
    }
}
