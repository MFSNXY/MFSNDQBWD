using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    class UsersmanConfiger : EntityTypeConfiguration<Usersman>
    {
        public UsersmanConfiger()
        {
            this.ToTable(nameof(Usersman));
            this.HasKey(e => e.u_oid);
            this.Property(e => e.u_name1).HasMaxLength(60);
            this.Property(e => e.u_sm).HasMaxLength(60);
            this.Property(e => e.u_sf).HasMaxLength(60);
        }
    }
}
