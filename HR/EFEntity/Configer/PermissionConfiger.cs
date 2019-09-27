using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class PermissionConfiger :EntityTypeConfiguration<Permission>
    {

        public PermissionConfiger()
        {
            this.ToTable(nameof(Permission));
            //this.Property(e => e.text).HasMaxLength(40);
            //this.Property(e => e.Url).HasMaxLength(50);
            //this.Property(e => e.state).HasMaxLength(20);
        }

    }
}
