using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EFEntity.Configer
{
    class UsersConfiger : EntityTypeConfiguration<Users>
    {
        public UsersConfiger()
        {
            this.ToTable(nameof(Users));
            this.HasKey(e => e.u_id);
            this.Property(e => e.u_name).HasMaxLength(60);
            this.Property(e => e.u_true_name).HasMaxLength(60);
            this.Property(e => e.u_password).HasMaxLength(60);
        }
    }
}
