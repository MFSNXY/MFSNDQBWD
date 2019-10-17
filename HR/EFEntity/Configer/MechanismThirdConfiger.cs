using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class MechanismThirdConfiger:EntityTypeConfiguration<MechanismThird>
    {

        public MechanismThirdConfiger()
        {
            this.ToTable(nameof(MechanismThird));
            this.Property(e => e.FirstMid).IsRequired().HasMaxLength(13);
            this.Property(e => e.FirstMName).IsRequired().HasMaxLength(30);
            this.Property(e => e.SecondMid).IsRequired().HasMaxLength(13);
            this.Property(e => e.SecondMName).IsRequired().HasMaxLength(30);
            this.Property(e => e.ThirdMid).IsRequired().HasMaxLength(13);
            this.Property(e => e.ThirdMName).IsRequired().HasMaxLength(30);
            this.Property(e => e.SalesId).IsRequired().HasMaxLength(100);
            this.Property(e => e.IsRetail).IsRequired().HasMaxLength(2);
        }

    }
}
