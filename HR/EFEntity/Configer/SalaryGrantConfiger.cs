using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    class SalaryGrantConfiger : EntityTypeConfiguration<SalaryGrant>
    {
        public SalaryGrantConfiger()
        {
            this.ToTable(nameof(SalaryGrant));

        }
    }
    }
