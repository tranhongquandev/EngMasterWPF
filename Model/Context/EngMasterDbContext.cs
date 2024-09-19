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

        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffRole> StaffRole { get; set; }





        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EngMasterDbContext).Assembly);
        }
    }
}
