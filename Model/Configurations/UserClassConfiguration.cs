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
            builder.HasOne(x => x.UserProfiles).WithMany(x => x.UserClasses).HasForeignKey(x => x.UserId);

            builder.HasData(
                 new UserClass
                 {
                     Id = 1,
                     UserId = 1,
                     ClassId = 1
                    
                 },
                    new UserClass
                    {
                        Id = 2,
                        UserId = 2,
                        ClassId = 1
                        
                       
                    },
                    new UserClass
                    {
                        Id = 3,
                        UserId = 3,
                        ClassId = 2
                        
                       
                    },
                    new UserClass
                    {
                        Id = 4,
                        UserId = 4,
                        ClassId = 2
                        
                       
                    },
                    new UserClass
                    {
                        Id = 5,
                        UserId = 5,
                        ClassId = 3
                        
                       
                    },
                    new UserClass
                    {
                        Id = 6,
                        UserId = 6,
                        ClassId = 3
                        
                       
                    },
                    new UserClass
                    {
                        Id = 7,
                        UserId = 7,
                        ClassId = 4
                        
                       
                    },
                    new UserClass
                    {
                        Id = 8,
                        UserId = 8,
                        ClassId = 4
                        
                       
                    },
                    new UserClass
                    {
                        Id = 9,
                        UserId = 9,
                        ClassId = 5
                        
                       
                    },
                    new UserClass
                    {
                        Id = 10,
                        UserId = 10,
                        ClassId = 5
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 11,
                        UserId = 11,
                        ClassId = 1
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 12,
                        UserId = 12,
                        ClassId = 2
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 13,
                        UserId = 13,
                        ClassId = 3
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 14,
                        UserId = 14,
                        ClassId = 4
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 15,
                        UserId = 15,
                        ClassId = 5
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 16,
                        UserId = 16,
                        ClassId = 1
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 17,
                        UserId = 17,
                        ClassId = 2
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 18,
                        UserId = 18,
                        ClassId = 3
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 19,
                        UserId = 19,
                        ClassId = 4
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 20,
                        UserId = 20,
                        ClassId = 5
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 21,
                        UserId = 21,
                        ClassId = 1
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 22,
                        UserId = 22,
                        ClassId = 2
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 23,
                        UserId = 23,
                        ClassId = 3
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 24,
                        UserId = 24,
                        ClassId = 4
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 25,
                        UserId = 25,
                        ClassId = 5
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 26,
                        UserId = 26,
                        ClassId = 1
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 27,
                        UserId = 27,
                        ClassId = 2
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 28,
                        UserId = 28,
                        ClassId = 3
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 29,
                        UserId = 29,
                        ClassId = 4
                        ,
                       
                    },
                    new UserClass
                    {
                        Id = 30,
                        UserId = 30,
                        ClassId = 5
                        ,
                       
                    }
                );
        }
    }
}
