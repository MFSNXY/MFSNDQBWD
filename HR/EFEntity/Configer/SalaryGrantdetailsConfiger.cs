using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class SalaryGrantdetailsConfiger : EntityTypeConfiguration<SalaryGrantdetails>
    {
        public SalaryGrantdetailsConfiger()
        {
            this.ToTable(nameof(SalaryGrantdetails));

        }
    }
}
