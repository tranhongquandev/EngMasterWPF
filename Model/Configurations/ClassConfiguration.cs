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
            builder.Property(x => x.ClassCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.ClassName).IsRequired();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.HasOne(x => x.Course).WithMany(x => x.Class).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Class).HasForeignKey(x => x.TeacherId);
        }

        //Generate random string function
        static string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 6;
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
