using EKART.USER.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Context
{
    public class EKartDbContext : DbContext
    {
        public EKartDbContext(DbContextOptions <EKartDbContext> options) : base(options) { }    

        public virtual DbSet  <EkartLoopUpRole> EkartLoopUpRole { get; set; }
        public virtual DbSet<EkartUserDetail> EkartUserDetail { get; set; }
        public virtual DbSet<EkartUserInRole> EkartUserInRole { get; set; }

        public virtual DbSet<EkartTokenDetails> EkartTokenDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EkartLoopUpRole>().ToTable("EkartLoopUpRole");
            modelBuilder.Entity<EkartUserDetail>().ToTable("EkartUserDetail");
            modelBuilder.Entity<EkartUserInRole>().ToTable("EkartUserInRole");
            modelBuilder.Entity<EkartTokenDetails>().ToTable("EkartTokenDetails");
        }
    }
}
