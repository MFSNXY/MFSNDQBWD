using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class XCFFST3Configer : EntityTypeConfiguration<XCFFST3>
    {
        public XCFFST3Configer()
        {
            this.ToTable(nameof(XCFFST3));

        }
    }
}
