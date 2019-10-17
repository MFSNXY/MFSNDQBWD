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
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            Database.SetInitializer<MyDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<PublicChar> PublicChar { get; set; }
        public DbSet<StandardDetails> StanderdDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Usersman> Usersman { get; set; }       
        public DbSet<View_User> View_User { get; set; }
        public DbSet<Authorityrole> Authorityrole { get; set; }
        public DbSet<View_Authorityrole> View_Authorityrole { get; set; }
        public DbSet<MechanismFirst> MechanismFirsts { get; set; }
        public DbSet<MechanismSecond> MechanismSeconds { get; set; }
        public DbSet<MechanismThird> MechanismThirds { get; set; }
        public DbSet<ConfigMajorKind> ConfigMajorKind { get; set; }
        public DbSet<ConfigMajor> ConfigMajor { get; set; }
        public DbSet<Major_change> Major_change { get; set; }
    }
}
