using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Entities
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            ToTable("Job");
            Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(500).IsRequired();
            HasMany(i => i.Employees)
                .WithRequired(i => i.Job)
                .HasForeignKey(i => i.JobID);
        }
    }
}
