using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    class PublicCharConfiger: EntityTypeConfiguration<PublicChar>
    {
        public PublicCharConfiger()
        {
            this.ToTable(nameof(PublicChar));
            this.HasKey(e => e.pbc_id);
            this.Property(e => e.attribute_kind).HasMaxLength(20);
            this.Property(e => e.attribute_name).HasMaxLength(20);
        }
    }
}
