using EngMasterWPF.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client.NativeInterop;
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
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Languages).WithMany(x => x.Levels).HasForeignKey(x => x.LanguageId);
            builder.HasData(
                    // English Levels
                    new Level { Id = 1,LanguageId = 1, Code = "A1", Name = "Beginner" },
                    new Level { Id = 2,LanguageId = 1, Code = "A2", Name = "Elementary" },
                    new Level { Id = 3,LanguageId = 1, Code = "B1", Name = "Intermediate" },
                    new Level { Id = 4,LanguageId = 1, Code = "B2", Name = "Upper Intermediate" },
                    new Level { Id = 5,LanguageId = 1, Code = "C1", Name = "Advanced" },
                    new Level { Id = 6,LanguageId = 1, Code = "C2", Name = "Proficient" },

                    // French Levels
                    new Level {Id = 7, LanguageId = 2, Code = "A1", Name = "Débutant" },
                    new Level {Id = 8, LanguageId = 2, Code = "A2", Name = "Élémentaire" },
                    new Level {Id = 9, LanguageId = 2, Code = "B1", Name = "Intermédiaire" },
                    new Level {Id = 10, LanguageId = 2, Code = "B2", Name = "Supérieur" },
                    new Level {Id = 11, LanguageId = 2, Code = "C1", Name = "Avancé" },
                    new Level {Id = 12, LanguageId = 2, Code = "C2", Name = "Maîtrise" },

                    // Spanish Levels
                    new Level {Id = 13, LanguageId = 3, Code = "A1", Name = "Principiante" },
                    new Level {Id = 14, LanguageId = 3, Code = "A2", Name = "Elemental" },
                    new Level {Id = 15, LanguageId = 3, Code = "B1", Name = "Intermedio" },
                    new Level {Id = 16, LanguageId = 3, Code = "B2", Name = "Avanzado" },
                    new Level {Id = 17, LanguageId = 3, Code = "C1", Name = "Superior" },
                    new Level {Id = 18, LanguageId = 3, Code = "C2", Name = "Maestría" },

                    // Chinese Levels
                    new Level {Id = 19, LanguageId = 4, Code = "HSK 1", Name = "Beginner" },
                    new Level {Id = 20, LanguageId = 4, Code = "HSK 2", Name = "Elementary" },
                    new Level {Id = 21, LanguageId = 4, Code = "HSK 3", Name = "Intermediate" },
                    new Level {Id = 22, LanguageId = 4, Code = "HSK 4", Name = "Upper Intermediate" },
                    new Level {Id = 23, LanguageId = 4, Code = "HSK 5", Name = "Advanced" },
                    new Level {Id = 24, LanguageId = 4, Code = "HSK 6", Name = "Proficient" },

                    // Japanese Levels
                    new Level {Id = 25, LanguageId = 5, Code = "N5", Name = "Beginner" },
                    new Level {Id = 26, LanguageId = 5, Code = "N4", Name = "Elementary" },
                    new Level {Id = 27, LanguageId = 5, Code = "N3", Name = "Intermediate" },
                    new Level {Id = 28, LanguageId = 5, Code = "N2", Name = "Upper Intermediate" },
                    new Level {Id = 29, LanguageId = 5, Code = "N1", Name = "Advanced" }



                );
        }
    }
}
