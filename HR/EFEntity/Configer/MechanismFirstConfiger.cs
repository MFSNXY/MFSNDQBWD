using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class MechanismFirstConfiger:EntityTypeConfiguration<MechanismFirst>
    {
        
        public MechanismFirstConfiger()
        {
            this.ToTable(nameof(MechanismFirst));
            this.Property(e => e.FirstMId).IsRequired().HasMaxLength(13);
            this.Property(e => e.FirstMName).IsRequired().HasMaxLength(30);
            this.Property(e => e.SalesId).IsRequired().HasMaxLength(100);
            this.Property(e => e.SalaryId).IsRequired().HasMaxLength(100);
        }

    }
}
