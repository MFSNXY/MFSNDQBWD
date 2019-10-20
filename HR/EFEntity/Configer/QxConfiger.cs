using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    class QxConfiger : EntityTypeConfiguration<Qx>
    {
        public QxConfiger()
        {
            this.ToTable(nameof(Qx));
            this.HasKey(e => e.id);
        }
    }
}
