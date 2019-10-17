using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    public class ConfigMajorConfiger : EntityTypeConfiguration<ConfigMajor>
    {
        public ConfigMajorConfiger()
        {
            this.ToTable(nameof(ConfigMajor));

        }
    }
}
