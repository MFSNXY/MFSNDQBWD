using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    public class View_UserConfiger: EntityTypeConfiguration<View_User>
    {
        public View_UserConfiger()
        {
            this.ToTable(nameof(View_User));
            this.HasKey(e => e.u_id);
            this.Property(e => e.u_name).HasMaxLength(60);
            this.Property(e => e.u_true_name).HasMaxLength(60);
            this.Property(e => e.u_password).HasMaxLength(60);
            this.Property(e => e.u_name1).HasMaxLength(60);
        }
    }
}
