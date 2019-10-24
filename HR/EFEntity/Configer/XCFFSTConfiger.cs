using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class XCFFSTConfiger : EntityTypeConfiguration<XCFFST>
    {
        public XCFFSTConfiger()
        {
            this.ToTable(nameof(XCFFST));

        }
    }
}
