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
    public class ClassStudentConfiguration : IEntityTypeConfiguration<ClassStudent>
    {
        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Class).WithMany(x => x.ClassStudents).HasForeignKey(x => x.ClassId);
            builder.HasOne(x => x.Student).WithMany(x => x.ClassStudents).HasForeignKey(x => x.StudentId);
        }
    }
}
