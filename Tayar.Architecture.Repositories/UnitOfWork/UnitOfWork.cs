using Tayar.Achitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.Repositories
{
    public class UnitOfWork
    {
        private EnitiesContext context;

        public Generic<Employee> EmployeeRepo { get; set; }
        public Generic<Job> JobRepo { get; set; }

        public UnitOfWork(
            EnitiesContext _context,

            Generic<Employee> employeeRepo,
            Generic<Job> jobRepo
            )
        {
            context = _context;
            EmployeeRepo = employeeRepo;
            EmployeeRepo.Context = context;
            JobRepo = jobRepo;
            JobRepo.Context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
