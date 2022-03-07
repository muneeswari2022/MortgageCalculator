using MortgageCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Models
{
    public class MortgageContext : DbContext
    {
        public MortgageContext() : base("Mortgage_Container")
        {
        }

        public DbSet<Mortgages> TblMortgage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MortgageContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }

        public System.Data.Entity.DbSet<MortgageCalculator.Dto.Mortgage> Mortgages { get; set; }
    }
}