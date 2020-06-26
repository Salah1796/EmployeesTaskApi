using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Entities
{
    public class BaseModelConfiguration : EntityTypeConfiguration<BaseModel>
    {
        public BaseModelConfiguration()
        {
            HasKey(i => i.ID);
            Property(i => i.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(i => i.IsDeleted)
             .HasColumnName("IsDeleted")
             .IsRequired();
        }
    }
}
