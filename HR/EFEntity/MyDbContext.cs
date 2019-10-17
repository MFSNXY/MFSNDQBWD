using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace EFEntity
{
    public class MyDbContext:DbContext
    {

        public MyDbContext() : base("sql")
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<ConfigMajorKind> ConfigMajorKind { get; set; }
        public DbSet<ConfigPublicChar> ConfigPublicChar { get; set; }
        public DbSet<ConfigMajor> ConfigMajor { get; set; }
        public DbSet<SalaryStandard> SalaryStandard { get; set; }
        public DbSet<SalaryStandardDetails> SalaryStandardDetails { get; set; }
        public DbSet<SalaryGrant> SalaryGrant { get; set; }
        public DbSet<SalaryGrantdetails> SalaryGrantdetails { get; set; }
        public DbSet<StandardDetails> StandardDetails { get; set; }
    }
}
