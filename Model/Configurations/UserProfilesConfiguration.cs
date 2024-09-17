using EngMasterWPF.Model.Entities;
using EngMasterWPF.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Configurations
{
    public class UserProfilesConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(120);
            builder.Property(x => x.StartAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue("Chưa có lớp");
            builder.Property(x => x.BirthDate);
            builder.HasOne(x => x.UserRoles).WithMany(x => x.UserProfiles).HasForeignKey(x => x.RoleId);

            builder.HasData
                (
                
                    new UserProfile
                    {
                        Id = 1,
                        FirstName = "Quản trị",
                        LastName = "viên",
                        Email = "engmaster.admin@gmail.com",
                        Phone = "0123456789",
                        Address = "123 Đường ABC, Ha Noi, VietNam",
                        RoleId = 1
                        

                    },

                    #region Mock Data Student

                    new UserProfile { Id = 42, FirstName = "John", LastName = "Doe",RoleId = 4, BirthDate = new DateTime(1998, 5, 15), Email = "john.doe1@example.com", Phone = "123456789",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 10), Status = "Chưa có lớp" },
                    new UserProfile { Id = 12, FirstName = "Jane", LastName = "Smith",RoleId = 4, BirthDate = new DateTime(2000, 8, 22), Email = "jane.smith1@example.com", Phone = "987654321",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 12), Status = "Chưa có lớp" },
                    new UserProfile { Id = 13, FirstName = "Tom", LastName = "Hanks",RoleId = 4, BirthDate = new DateTime(1997, 7, 11), Email = "tom.hanks1@example.com", Phone = "555111222",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 14), Status = "Chưa có lớp" },
                    new UserProfile { Id = 14, FirstName = "Emily", LastName = "Johnson",RoleId = 4, BirthDate = new DateTime(1999, 11, 10), Email = "emily.johnson1@example.com", Phone = "123123123",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 16), Status = "Chưa có lớp" },
                    new UserProfile { Id = 15, FirstName = "Michael", LastName = "Brown",RoleId = 4, BirthDate = new DateTime(1995, 12, 1), Email = "michael.brown1@example.com", Phone = "321321321",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 18), Status = "Chưa có lớp" },
                    new UserProfile { Id = 16, FirstName = "Jessica", LastName = "Williams",RoleId = 4, BirthDate = new DateTime(2001, 5, 5), Email = "jessica.williams1@example.com", Phone = "555987654",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 20), Status = "Chưa có lớp" },
                    new UserProfile { Id = 17, FirstName = "David", LastName = "Miller",RoleId = 4, BirthDate = new DateTime(1996, 4, 12), Email = "david.miller1@example.com", Phone = "456789123",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 22), Status = "Chưa có lớp" },
                    new UserProfile { Id = 18, FirstName = "Sarah", LastName = "Davis",RoleId = 4, BirthDate = new DateTime(1994, 2, 18), Email = "sarah.davis1@example.com", Phone = "111222333",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 24), Status = "Chưa có lớp" },
                    new UserProfile { Id = 19, FirstName = "Chris", LastName = "Wilson",RoleId = 4, BirthDate = new DateTime(1999, 9, 9), Email = "chris.wilson1@example.com", Phone = "444555666",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 26), Status = "Chưa có lớp" },
                    new UserProfile { Id = 20, FirstName = "Laura", LastName = "Martinez",RoleId = 4, BirthDate = new DateTime(1998, 3, 20), Email = "laura.martinez1@example.com", Phone = "777888999",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 1, 28), Status = "Chưa có lớp" },
                    new UserProfile { Id = 21, FirstName = "Ryan", LastName = "Garcia",RoleId = 4, BirthDate = new DateTime(1997, 7, 22), Email = "ryan.garcia1@example.com", Phone = "123987654",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 1), Status = "Chưa có lớp" },
                    new UserProfile { Id = 22, FirstName = "Sophia", LastName = "Lee",RoleId = 4, BirthDate = new DateTime(2002, 1, 10), Email = "sophia.lee1@example.com", Phone = "987123456",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 3), Status = "Chưa có lớp" },
                    new UserProfile { Id = 23, FirstName = "Daniel", LastName = "Hernandez",RoleId = 4, BirthDate = new DateTime(2001, 9, 15), Email = "daniel.hernandez1@example.com", Phone = "333666999",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 5), Status = "Chưa có lớp" },
                    new UserProfile { Id = 24, FirstName = "Lisa", LastName = "Moore",RoleId = 4, BirthDate = new DateTime(2003, 8, 19), Email = "lisa.moore1@example.com", Phone = "789123456",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 7), Status = "Chưa có lớp" },
                    new UserProfile { Id = 25, FirstName = "Adam", LastName = "Taylor",RoleId = 4, BirthDate = new DateTime(1996, 6, 30), Email = "adam.taylor1@example.com", Phone = "654321987",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 9), Status = "Chưa có lớp" },
                    new UserProfile { Id = 26, FirstName = "Megan", LastName = "Anderson",RoleId = 4, BirthDate = new DateTime(2001, 4, 10), Email = "megan.anderson1@example.com", Phone = "222111000",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 11), Status="Đã có lớp" },
                    new UserProfile { Id = 27, FirstName = "Oliver", LastName = "Thomas",RoleId = 4, BirthDate = new DateTime(1997, 11, 13), Email = "oliver.thomas1@example.com", Phone = "999888777",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 13), Status="Đã có lớp" },
                    new UserProfile { Id = 28, FirstName = "Natalie", LastName = "Jackson",RoleId = 4, BirthDate = new DateTime(2002, 2, 5), Email = "natalie.jackson1@example.com", Phone = "555444333",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 15), Status="Đã có lớp" },
                    new UserProfile { Id = 29, FirstName = "Liam", LastName = "White",RoleId = 4, BirthDate = new DateTime(1999, 12, 12), Email = "liam.white1@example.com", Phone = "987321654",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 17), Status="Đã có lớp" },
                    new UserProfile { Id = 30, FirstName = "Emma", LastName = "Harris",RoleId = 4, BirthDate = new DateTime(1998, 7, 20), Email = "emma.harris1@example.com", Phone = "321654987",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 19), Status="Đã có lớp" },
                    new UserProfile { Id = 31, FirstName = "James", LastName = "Clark",RoleId = 4, BirthDate = new DateTime(2000, 10, 21), Email = "james.clark1@example.com", Phone = "111999888",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 21), Status="Đã có lớp" },
                    new UserProfile { Id = 32, FirstName = "Anna", LastName = "Lewis",RoleId = 4, BirthDate = new DateTime(2003, 6, 18), Email = "anna.lewis1@example.com", Phone = "555777444",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 23), Status="Đã có lớp" },
                    new UserProfile { Id = 33, FirstName = "Jack", LastName = "Walker",RoleId = 4, BirthDate = new DateTime(1998, 9, 9), Email = "jack.walker1@example.com", Phone = "777666555",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 25), Status="Đã có lớp" },
                    new UserProfile { Id = 34, FirstName = "Zoe", LastName = "Hall",RoleId = 4, BirthDate = new DateTime(2001, 11, 11), Email = "zoe.hall1@example.com", Phone = "123111222",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 27), Status="Đã có lớp" },
                    new UserProfile { Id = 35, FirstName = "Ethan", LastName = "Allen",RoleId = 4, BirthDate = new DateTime(1997, 5, 22), Email = "ethan.allen1@example.com", Phone = "321888999",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 2, 29), Status="Đã có lớp" },
                    new UserProfile { Id = 36, FirstName = "Grace", LastName = "Young",RoleId = 4, BirthDate = new DateTime(2002, 3, 10), Email = "grace.young1@example.com", Phone = "555123789",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 3, 2), Status="Đã có lớp" },
                    new UserProfile { Id = 37, FirstName = "Benjamin", LastName = "King",RoleId = 4, BirthDate = new DateTime(1996, 8, 5), Email = "benjamin.king1@example.com", Phone = "789654123",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 3, 4), Status="Đã có lớp" },
                    new UserProfile { Id = 38, FirstName = "Ava", LastName = "Scott",RoleId = 4, BirthDate = new DateTime(2003, 12, 25), Email = "ava.scott1@example.com", Phone = "654987321", Address = "123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 3, 6) , Status = "Đã có lớp"},
                    new UserProfile { Id = 39, FirstName = "Henry", LastName = "Adams",RoleId = 4, BirthDate = new DateTime(2000, 7, 7), Email = "henry.adams1@example.com", Phone = "777111444",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 3, 8) , Status = "Đã có lớp"},
                    new UserProfile { Id = 40, FirstName = "Chloe", LastName = "Baker",RoleId = 4, BirthDate = new DateTime(1997, 10, 16), Email = "chloe.baker1@example.com", Phone = "555666777",Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2024, 3, 10), Status = "Chưa có lớp" },

                    #endregion

                    #region Mock Data Teacher
                    new UserProfile { Id = 2,FirstName = "Emily", LastName = "Johnson",RoleId =3,Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2021, 6, 15), Email = "emily.johnson1@example.com", Phone = "123123123", Status="Đang làm việc" },
                    new UserProfile { Id = 3,FirstName = "Michael", LastName = "Brown",RoleId =3,Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2022, 1, 10), Email = "michael.brown1@example.com", Phone = "321321321", Status="Đang làm việc" },
                    new UserProfile { Id = 4,FirstName = "Olivia", LastName = "Davis",RoleId =3,Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2020, 8, 22), Email = "olivia.davis1@example.com", Phone = "987987987", Status="Đang làm việc" },
                    new UserProfile { Id = 5,FirstName = "William", LastName = "Martinez",RoleId =3,Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2019, 11, 5), Email = "william.martinez1@example.com", Phone = "654654654", Status="Đang làm việc" },
                    new UserProfile { Id = 6,FirstName = "Sophia", LastName = "Wilson",RoleId =3,Address="123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2023, 2, 14), Email = "sophia.wilson1@example.com", Phone = "789789789", Status="Đang làm việc" },
                     new UserProfile { Id = 7,FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1998, 5, 15), Email = "john.doe1@example.com", Phone = "123456789", RoleId =3,Address = "123 Đường ABC, Hà Nội, VN", StartAt = new DateTime(2020, 8, 22), HireAt = new DateTime(2024, 1, 10), Status = "Đã nghỉ" },
                    new UserProfile { Id = 8,FirstName = "Jane", LastName = "Smith", BirthDate = new DateTime(2000, 8, 22), Email = "jane.smith1@example.com", Phone = "987654321", RoleId =3,Address = "123 Đường ABC, Hà Nội, VN",  StartAt = new DateTime(2020, 8, 22),HireAt = new DateTime(2024, 1, 12), Status = "Đã nghỉ" },
                    new UserProfile { Id = 9,FirstName = "Tom", LastName = "Hanks", BirthDate = new DateTime(1997, 7, 11), Email = "tom.hanks1@example.com", Phone = "555111222", RoleId =3,Address = "123 Đường ABC, Hà Nội, VN",  StartAt = new DateTime(2020, 8, 22),HireAt = new DateTime(2024, 1, 14), Status = "Đã nghỉ" },
                    new UserProfile { Id = 10,FirstName = "Emily", LastName = "Johnson", BirthDate = new DateTime(1999, 11, 10), Email = "emily.johnson1@example.com", Phone = "123123123", RoleId =3,Address = "123 Đường ABC, Hà Nội, VN",  StartAt = new DateTime(2020, 8, 22),HireAt = new DateTime(2024, 1, 16), Status = "Đã nghỉ" },
                    new UserProfile { Id = 11,FirstName = "Michael", LastName = "Brown", BirthDate = new DateTime(1995, 12, 1), Email = "michael.brown1@example.com", Phone = "321321321", RoleId =3,Address = "123 Đường ABC, Hà Nội, VN",  StartAt = new DateTime(2020, 8, 22),HireAt = new DateTime(2024, 1, 18), Status = "Đã nghỉ" }
                    #endregion




                );

        }
    }
}
