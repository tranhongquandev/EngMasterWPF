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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TeacherCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.ImgUrl).HasMaxLength(255);
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.HireDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

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
