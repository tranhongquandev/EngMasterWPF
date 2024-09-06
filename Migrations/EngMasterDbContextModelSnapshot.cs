﻿// <auto-generated />
using System;
using EngMasterWPF.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EngMasterWPF.Migrations
{
    [DbContext(typeof(EngMasterDbContext))]
    partial class EngMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.ClassStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassStudents");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.ClassWeekday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("WeekdayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("WeekdayId");

                    b.ToTable("ClassWeekdays");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Term")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Code");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LevelId");

                    b.HasIndex("Name");

                    b.HasIndex("Term");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 9, 6, 7, 13, 59, 369, DateTimeKind.Utc).AddTicks(3474));

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("PaymentStatusId")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Thanh toán tiền mặt"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chuyển khoản ngân hàng"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thẻ VISA"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ví điện tử"
                        });
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Created"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Pending"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Success"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Cancel"
                        });
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 9, 6, 7, 13, 59, 370, DateTimeKind.Utc).AddTicks(6766));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StaffRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffRolesId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StaffRolesId");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Đường ABC",
                            City = "Hồ Chí Minh",
                            Email = "engmaster.admin@gmail.com",
                            FirstName = "Quản trị",
                            LastName = "viên",
                            Phone = "0123456789",
                            StaffRoleId = 1,
                            State = "Việt Nam"
                        });
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StaffAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("StaffId")
                        .IsUnique();

                    b.ToTable("StaffAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1234567890@aA",
                            StaffId = 1,
                            Username = "engmaster.admin",
                            isActive = true
                        });
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StaffRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rank")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StaffRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            Rank = 1
                        });
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StudentAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentAccounts");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.TeacherAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("TeacherAccounts");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Weekday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Weekdays");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Class", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.ClassStudent", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Class", "Class")
                        .WithMany("ClassStudents")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Student", "Student")
                        .WithMany("ClassStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.ClassWeekday", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Class", "Class")
                        .WithMany("ClassWeekdays")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Weekday", "Weekday")
                        .WithMany("ClassWeekdays")
                        .HasForeignKey("WeekdayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Weekday");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Course", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Language", "Language")
                        .WithMany("Courses")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Level", "Level")
                        .WithMany("Courses")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Language");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Payment", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Class", "Class")
                        .WithMany("Payments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.PaymentStatus", "Status")
                        .WithOne("Payments")
                        .HasForeignKey("EngMasterWPF.Model.Entities.Payment", "PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngMasterWPF.Model.Entities.Student", "Student")
                        .WithMany("Payments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Status");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Staff", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.StaffRoles", "StaffRoles")
                        .WithMany("Staffs")
                        .HasForeignKey("StaffRolesId");

                    b.Navigation("StaffRoles");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StaffAccount", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Staff", "Staff")
                        .WithOne("StaffAccount")
                        .HasForeignKey("EngMasterWPF.Model.Entities.StaffAccount", "StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StudentAccount", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Student", "Student")
                        .WithOne("StudentAccount")
                        .HasForeignKey("EngMasterWPF.Model.Entities.StudentAccount", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.TeacherAccount", b =>
                {
                    b.HasOne("EngMasterWPF.Model.Entities.Teacher", "Teacher")
                        .WithOne("TeacherAccount")
                        .HasForeignKey("EngMasterWPF.Model.Entities.TeacherAccount", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Class", b =>
                {
                    b.Navigation("ClassStudents");

                    b.Navigation("ClassWeekdays");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Course", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Language", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Level", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Staff", b =>
                {
                    b.Navigation("StaffAccount");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.StaffRoles", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Student", b =>
                {
                    b.Navigation("ClassStudents");

                    b.Navigation("Payments");

                    b.Navigation("StudentAccount");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("TeacherAccount");
                });

            modelBuilder.Entity("EngMasterWPF.Model.Entities.Weekday", b =>
                {
                    b.Navigation("ClassWeekdays");
                });
#pragma warning restore 612, 618
        }
    }
}
