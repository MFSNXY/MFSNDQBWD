using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class View_AuthorityroleConfiger : EntityTypeConfiguration<View_Authorityrole>
    {
        public View_AuthorityroleConfiger()
        {
            this.ToTable(nameof(View_Authorityrole));
            this.HasKey(e => e.pid);
            this.Property(e => e.u_oid).IsRequired().HasMaxLength(40);
            this.Property(e => e.text).IsRequired().HasMaxLength(40);
        }
    }
}
