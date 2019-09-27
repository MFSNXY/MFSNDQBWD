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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<PublicChar> PublicChar { get; set; }
        public DbSet<StandardDetails> StanderdDetails { get; set; }
    }
}
