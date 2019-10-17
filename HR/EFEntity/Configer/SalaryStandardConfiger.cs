using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class SalaryStandardConfiger : EntityTypeConfiguration<SalaryStandard>
    {
        public SalaryStandardConfiger()
        {
            this.ToTable(nameof(SalaryStandard));
        }
    } 
    }
