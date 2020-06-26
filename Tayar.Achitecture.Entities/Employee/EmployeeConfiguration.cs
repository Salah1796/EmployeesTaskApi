using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Entities
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");

             Property(i => i.Name)
              .HasColumnName("Name")
              .HasMaxLength(500)
              .IsRequired();
            Property(i => i.Email)
             .HasColumnName("Email")
             .HasMaxLength(500)
             .IsRequired();
            Property(i => i.Phone)
         .HasColumnName("Phone")
         .HasMaxLength(11)
         .IsRequired();
            Property(i => i.NationalID)
           .HasColumnName("NationalID")
           .HasMaxLength(14)
           .IsRequired();

            Property(i => i.Gender)
          .HasColumnName("Gender")
          .IsRequired();
            Property(i => i.Date)
              .HasColumnName("Date")
              .IsRequired();
            Property(i => i.IsActive)
        .HasColumnName("IsActive")
        .IsRequired();

            HasRequired(i => i.Job)
                .WithMany(i => i.Employees)
                .HasForeignKey(i => i.JobID);
        }
    }
}
