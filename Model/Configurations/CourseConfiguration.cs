﻿using EngMasterWPF.Model.Entities;
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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CourseCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.CourseName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Fee).HasDefaultValue(0);
            builder.Property(x => x.Discount).HasDefaultValue(0);
            builder.Property(x => x.TotalFee).HasDefaultValue(0);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne(x => x.Language).WithMany(x => x.Course).HasForeignKey(x => x.LanguageId);

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
