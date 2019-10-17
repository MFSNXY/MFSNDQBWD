using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class AuthorityroleConfiger : EntityTypeConfiguration<Authorityrole>
    {
        public AuthorityroleConfiger()
        {
            this.ToTable(nameof(Authorityrole));
            this.HasKey(e => e.pid);
            this.Property(e => e.u_oid).IsRequired().HasMaxLength(40);
            this.Property(e => e.aut_id).IsRequired().HasMaxLength(40);
        }
    }
}
