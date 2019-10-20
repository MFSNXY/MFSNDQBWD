using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class Major_changeConfiger : EntityTypeConfiguration<Major_change>
    {
        public Major_changeConfiger()
        {
            this.ToTable(nameof(Major_change));
            this.HasKey(e => e.mch_id);
        }
    }
}
