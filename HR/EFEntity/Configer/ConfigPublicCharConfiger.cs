using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class ConfigPublicCharConfiger : EntityTypeConfiguration<ConfigPublicChar>
    {
        public ConfigPublicCharConfiger()
        {
            this.ToTable(nameof(ConfigPublicChar));
            this.Property(e => e.Attributekind).HasMaxLength(60);
            this.Property(e => e.Attributename).HasMaxLength(60);
        }
    }
}
