using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class ConfigMajorKindConfiger:EntityTypeConfiguration<ConfigMajorKind>
    {
        public ConfigMajorKindConfiger()
        {
            this.ToTable(nameof(ConfigMajorKind));
            this.Property(e => e.Majorkindid).HasMaxLength(2);
            this.Property(e => e.Majorkindname).HasMaxLength(60);
        }
    }
}
