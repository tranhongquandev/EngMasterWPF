using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngMasterWPF.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekdays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    HireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Chưa có lớp")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "M8IQ1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserAccountsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_UserAccounts_UserAccountsId",
                        column: x => x.UserAccountsId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassWeekdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    WeekdayId = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndHour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWeekdays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassWeekdays_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassWeekdays_Weekdays_WeekdayId",
                        column: x => x.WeekdayId,
                        principalTable: "Weekdays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 9, 17, 13, 6, 16, 79, DateTimeKind.Utc).AddTicks(1968)),
                    PaymentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_UserAccounts_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClasses_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh" },
                    { 2, "Tiếng Pháp" },
                    { 3, "Tiếng Tây Ban Nha" },
                    { 4, "Tiếng Trung" },
                    { 5, "Tiếng Nhật" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Thanh toán tiền mặt" },
                    { 2, "Chuyển khoản ngân hàng" },
                    { 3, "Thẻ VISA" },
                    { 4, "Ví điện tử" }
                });

            migrationBuilder.InsertData(
                table: "PaymentStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Pending" },
                    { 3, "Success" },
                    { 4, "Cancel" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[,]
                {
                    { 1, "Admin", 1 },
                    { 2, "Staff", 2 },
                    { 3, "Teacher", 3 },
                    { 4, "Student", 4 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "LanguageId", "LevelId", "Name" },
                values: new object[,]
                {
                    { 1, "Basic English course for beginners.", 1, null, "English for Beginners" },
                    { 2, "For learners who have some experience.", 1, null, "Intermediate English" },
                    { 3, "Advanced course for experienced learners.", 1, null, "Advanced English" },
                    { 4, "Specialized course for business professionals.", 1, null, "Business English" },
                    { 5, "English course designed for travelers.", 1, null, "English for Travel" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Code", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "A1", 1, "Beginner" },
                    { 2, "A2", 1, "Elementary" },
                    { 3, "B1", 1, "Intermediate" },
                    { 4, "B2", 1, "Upper Intermediate" },
                    { 5, "C1", 1, "Advanced" },
                    { 6, "C2", 1, "Proficient" },
                    { 7, "A1", 2, "Débutant" },
                    { 8, "A2", 2, "Élémentaire" },
                    { 9, "B1", 2, "Intermédiaire" },
                    { 10, "B2", 2, "Supérieur" },
                    { 11, "C1", 2, "Avancé" },
                    { 12, "C2", 2, "Maîtrise" },
                    { 13, "A1", 3, "Principiante" },
                    { 14, "A2", 3, "Elemental" },
                    { 15, "B1", 3, "Intermedio" },
                    { 16, "B2", 3, "Avanzado" },
                    { 17, "C1", 3, "Superior" },
                    { 18, "C2", 3, "Maestría" },
                    { 19, "HSK 1", 4, "Beginner" },
                    { 20, "HSK 2", 4, "Elementary" },
                    { 21, "HSK 3", 4, "Intermediate" },
                    { 22, "HSK 4", 4, "Upper Intermediate" },
                    { 23, "HSK 5", 4, "Advanced" },
                    { 24, "HSK 6", 4, "Proficient" },
                    { 25, "N5", 5, "Beginner" },
                    { 26, "N4", 5, "Elementary" },
                    { 27, "N3", 5, "Intermediate" },
                    { 28, "N2", 5, "Upper Intermediate" },
                    { 29, "N1", 5, "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "FirstName", "HireAt", "LastName", "Phone", "RoleId", "Sex" },
                values: new object[] { 1, "123 Đường ABC, Ha Noi, VietNam", null, "engmaster.admin@gmail.com", "Quản trị", null, "viên", "0123456789", 1, null });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "FirstName", "HireAt", "LastName", "Phone", "RoleId", "Sex", "StartAt", "Status" },
                values: new object[,]
                {
                    { 2, "123 Đường ABC, Hà Nội, VN", null, "emily.johnson1@example.com", "Emily", null, "Johnson", "123123123", 3, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang làm việc" },
                    { 3, "123 Đường ABC, Hà Nội, VN", null, "michael.brown1@example.com", "Michael", null, "Brown", "321321321", 3, null, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang làm việc" },
                    { 4, "123 Đường ABC, Hà Nội, VN", null, "olivia.davis1@example.com", "Olivia", null, "Davis", "987987987", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang làm việc" },
                    { 5, "123 Đường ABC, Hà Nội, VN", null, "william.martinez1@example.com", "William", null, "Martinez", "654654654", 3, null, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang làm việc" },
                    { 6, "123 Đường ABC, Hà Nội, VN", null, "sophia.wilson1@example.com", "Sophia", null, "Wilson", "789789789", 3, null, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang làm việc" },
                    { 7, "123 Đường ABC, Hà Nội, VN", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe1@example.com", "John", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "123456789", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã nghỉ" },
                    { 8, "123 Đường ABC, Hà Nội, VN", new DateTime(2000, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith1@example.com", "Jane", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "987654321", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã nghỉ" },
                    { 9, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom.hanks1@example.com", "Tom", new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hanks", "555111222", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã nghỉ" },
                    { 10, "123 Đường ABC, Hà Nội, VN", new DateTime(1999, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson1@example.com", "Emily", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "123123123", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã nghỉ" },
                    { 11, "123 Đường ABC, Hà Nội, VN", new DateTime(1995, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown1@example.com", "Michael", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "321321321", 3, null, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã nghỉ" },
                    { 12, "123 Đường ABC, Hà Nội, VN", new DateTime(2000, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith1@example.com", "Jane", null, "Smith", "987654321", 4, null, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 13, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom.hanks1@example.com", "Tom", null, "Hanks", "555111222", 4, null, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 14, "123 Đường ABC, Hà Nội, VN", new DateTime(1999, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson1@example.com", "Emily", null, "Johnson", "123123123", 4, null, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 15, "123 Đường ABC, Hà Nội, VN", new DateTime(1995, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown1@example.com", "Michael", null, "Brown", "321321321", 4, null, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 16, "123 Đường ABC, Hà Nội, VN", new DateTime(2001, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessica.williams1@example.com", "Jessica", null, "Williams", "555987654", 4, null, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 17, "123 Đường ABC, Hà Nội, VN", new DateTime(1996, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.miller1@example.com", "David", null, "Miller", "456789123", 4, null, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 18, "123 Đường ABC, Hà Nội, VN", new DateTime(1994, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.davis1@example.com", "Sarah", null, "Davis", "111222333", 4, null, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 19, "123 Đường ABC, Hà Nội, VN", new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "chris.wilson1@example.com", "Chris", null, "Wilson", "444555666", 4, null, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 20, "123 Đường ABC, Hà Nội, VN", new DateTime(1998, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "laura.martinez1@example.com", "Laura", null, "Martinez", "777888999", 4, null, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 21, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ryan.garcia1@example.com", "Ryan", null, "Garcia", "123987654", 4, null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 22, "123 Đường ABC, Hà Nội, VN", new DateTime(2002, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.lee1@example.com", "Sophia", null, "Lee", "987123456", 4, null, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 23, "123 Đường ABC, Hà Nội, VN", new DateTime(2001, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel.hernandez1@example.com", "Daniel", null, "Hernandez", "333666999", 4, null, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 24, "123 Đường ABC, Hà Nội, VN", new DateTime(2003, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.moore1@example.com", "Lisa", null, "Moore", "789123456", 4, null, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 25, "123 Đường ABC, Hà Nội, VN", new DateTime(1996, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam.taylor1@example.com", "Adam", null, "Taylor", "654321987", 4, null, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 26, "123 Đường ABC, Hà Nội, VN", new DateTime(2001, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "megan.anderson1@example.com", "Megan", null, "Anderson", "222111000", 4, null, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 27, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "oliver.thomas1@example.com", "Oliver", null, "Thomas", "999888777", 4, null, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 28, "123 Đường ABC, Hà Nội, VN", new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "natalie.jackson1@example.com", "Natalie", null, "Jackson", "555444333", 4, null, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 29, "123 Đường ABC, Hà Nội, VN", new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam.white1@example.com", "Liam", null, "White", "987321654", 4, null, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 30, "123 Đường ABC, Hà Nội, VN", new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.harris1@example.com", "Emma", null, "Harris", "321654987", 4, null, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 31, "123 Đường ABC, Hà Nội, VN", new DateTime(2000, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.clark1@example.com", "James", null, "Clark", "111999888", 4, null, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 32, "123 Đường ABC, Hà Nội, VN", new DateTime(2003, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.lewis1@example.com", "Anna", null, "Lewis", "555777444", 4, null, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 33, "123 Đường ABC, Hà Nội, VN", new DateTime(1998, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "jack.walker1@example.com", "Jack", null, "Walker", "777666555", 4, null, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 34, "123 Đường ABC, Hà Nội, VN", new DateTime(2001, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "zoe.hall1@example.com", "Zoe", null, "Hall", "123111222", 4, null, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 35, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethan.allen1@example.com", "Ethan", null, "Allen", "321888999", 4, null, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 36, "123 Đường ABC, Hà Nội, VN", new DateTime(2002, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace.young1@example.com", "Grace", null, "Young", "555123789", 4, null, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 37, "123 Đường ABC, Hà Nội, VN", new DateTime(1996, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "benjamin.king1@example.com", "Benjamin", null, "King", "789654123", 4, null, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 38, "123 Đường ABC, Hà Nội, VN", new DateTime(2003, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ava.scott1@example.com", "Ava", null, "Scott", "654987321", 4, null, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 39, "123 Đường ABC, Hà Nội, VN", new DateTime(2000, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "henry.adams1@example.com", "Henry", null, "Adams", "777111444", 4, null, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đã có lớp" },
                    { 40, "123 Đường ABC, Hà Nội, VN", new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "chloe.baker1@example.com", "Chloe", null, "Baker", "555666777", 4, null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" },
                    { 42, "123 Đường ABC, Hà Nội, VN", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe1@example.com", "John", null, "Doe", "123456789", 4, null, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa có lớp" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Code", "CourseId", "Description", "EndDate", "Name", "Price", "StartDate", "UserAccountsId" },
                values: new object[,]
                {
                    { 1, null, 1, "Lớp học tiếng Anh A", new DateTime(2024, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Class A", 100000000m, new DateTime(2024, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, null, 5, "Lớp học tiếng Anh B", new DateTime(2024, 9, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), "Class B", 2000000m, new DateTime(2024, 9, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, null, 3, "Lớp học tiếng Anh C", new DateTime(2024, 9, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Class C", 3000000m, new DateTime(2024, 9, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, null, 5, "Lớp học tiếng Anh D", new DateTime(2024, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Class D", 4000000m, new DateTime(2024, 9, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, null, 4, "Lớp học tiếng Anh E", new DateTime(2024, 9, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Class E", 5000000m, new DateTime(2024, 9, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "IsActive", "PasswordHash", "UserProfileId", "Username" },
                values: new object[] { 1, true, "$2a$13$8xZgAat/fID8u.4MYn3gk.3BoxfuT8umfTClNDt7wDaSZALc5e3.y", 1, "admin" });

            migrationBuilder.InsertData(
                table: "UserClasses",
                columns: new[] { "Id", "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 },
                    { 7, 4, 7 },
                    { 8, 4, 8 },
                    { 9, 5, 9 },
                    { 10, 5, 10 },
                    { 11, 1, 11 },
                    { 12, 2, 12 },
                    { 13, 3, 13 },
                    { 14, 4, 14 },
                    { 15, 5, 15 },
                    { 16, 1, 16 },
                    { 17, 2, 17 },
                    { 18, 3, 18 },
                    { 19, 4, 19 },
                    { 20, 5, 20 },
                    { 21, 1, 21 },
                    { 22, 2, 22 },
                    { 23, 3, 23 },
                    { 24, 4, 24 },
                    { 25, 5, 25 },
                    { 26, 1, 26 },
                    { 27, 2, 27 },
                    { 28, 3, 28 },
                    { 29, 4, 29 },
                    { 30, 5, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserAccountsId",
                table: "Classes",
                column: "UserAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWeekdays_ClassId",
                table: "ClassWeekdays",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWeekdays_WeekdayId",
                table: "ClassWeekdays",
                column: "WeekdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Code",
                table: "Courses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LanguageId",
                table: "Levels",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClassId",
                table: "Payments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStatusId",
                table: "Payments",
                column: "PaymentStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentId",
                table: "Payments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserProfileId",
                table: "UserAccounts",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClasses_ClassId",
                table: "UserClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClasses_UserId",
                table: "UserClasses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_RoleId",
                table: "UserProfiles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassWeekdays");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "UserClasses");

            migrationBuilder.DropTable(
                name: "Weekdays");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
