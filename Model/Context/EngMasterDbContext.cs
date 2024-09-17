using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngMasterWPF.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EngMasterWPF.Model.Context
{
    public class EngMasterDbContext : DbContext
    {
        public EngMasterDbContext(DbContextOptions<EngMasterDbContext> options) : base(options)
        {
        }

        #region DbSet


        

        public virtual DbSet<Class> Classes { get; set; }   

        public virtual DbSet<UserClass> UserClasses { get; set; }

        public virtual DbSet<ClassWeekday> ClassWeekdays { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Level> Levels { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<UserRoles> UserRoles { get; set; }

        public virtual DbSet<UserAccounts> UserAccounts { get; set; }

        public virtual DbSet<Weekday> Weekdays { get; set; }

       

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EngMasterDbContext).Assembly);
        }
    }
}
