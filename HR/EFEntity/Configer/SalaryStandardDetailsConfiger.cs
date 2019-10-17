using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class SalaryStandardDetailsConfiger : EntityTypeConfiguration<SalaryStandardDetails>
    {
        public SalaryStandardDetailsConfiger()
        {
            this.ToTable(nameof(SalaryStandardDetails));

        }
    }
}
