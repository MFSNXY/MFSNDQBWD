using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class XCFFST2Configer : EntityTypeConfiguration<XCFFST2>
    {
        public XCFFST2Configer()
        {
            this.ToTable(nameof(XCFFST2));

        }
    }
}
