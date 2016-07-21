using SCMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace SCMS.DAL
{
    public class SCMSContext : DbContext

    {
        public SCMSContext() : base("SCMSContext")
        {
        }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<CunltivationDetail> CunltivationDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
