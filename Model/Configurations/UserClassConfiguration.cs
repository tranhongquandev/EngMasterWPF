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
    public class UserClassConfiguration : IEntityTypeConfiguration<UserClass>
    {
        public void Configure(EntityTypeBuilder<UserClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Class).WithMany(x => x.UserClasses).HasForeignKey(x => x.ClassId);
            builder.HasOne(x => x.UserAccounts).WithMany(x => x.UserClasses).HasForeignKey(x => x.UserAccountId);
        }
    }
}
