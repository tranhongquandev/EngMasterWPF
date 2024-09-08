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
    public class UserAccountsConfiguration : IEntityTypeConfiguration<UserAccounts>
    {
        public void Configure(EntityTypeBuilder<UserAccounts> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.HasOne(x => x.UserRoles).WithMany(x => x.UserAccounts).HasForeignKey(x => x.UserRoleId);
            builder.HasOne(x => x.UserProfile).WithOne(x => x.UserAccounts).HasForeignKey<UserAccounts>(x => x.UserProfileId);

            builder.HasData
            (
                new UserAccounts { Id = 1, Username = "admin", PasswordHash = "$2a$13$8xZgAat/fID8u.4MYn3gk.3BoxfuT8umfTClNDt7wDaSZALc5e3.y", IsActive = true, UserProfileId = 1, UserRoleId = 1 }
                
            );

        }
    }
}
