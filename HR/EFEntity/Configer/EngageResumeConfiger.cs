using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class EngageResumeConfiger:EntityTypeConfiguration<EngageResume>
    {

        public EngageResumeConfiger()
        {
            this.ToTable(nameof(EngageResume));
        }
    }
}
