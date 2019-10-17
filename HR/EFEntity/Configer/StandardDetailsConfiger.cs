using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    class StandardDetailsConfiger : EntityTypeConfiguration<StandardDetails>
    {
        public StandardDetailsConfiger()
        {
            this.ToTable(nameof(StandardDetails));
            this.HasKey(e => e.item_id);
            this.Property(e => e.item_name).HasMaxLength(60);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class StandardDetailsConfiger : EntityTypeConfiguration<StandardDetails>
    {
        public StandardDetailsConfiger()
        {
            this.ToTable(nameof(StandardDetails));
            this.HasKey(e => e.item_id);
        }
    }
}
