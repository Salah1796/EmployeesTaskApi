using Tayar.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.Repositories
{
    public class EnitiesContext : DbContext
    {
        public EnitiesContext() : base("name=TayarDb")
        { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add
               (new EmployeeConfiguration());
            modelBuilder.Configurations.Add
               (new JobConfiguration());
        }

    }
}
