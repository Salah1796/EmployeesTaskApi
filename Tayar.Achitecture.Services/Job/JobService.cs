using Tayar.Achitecture.Entities;
using Tayar.Architecture.Repositories;
using Tayar.Architecture.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.Services
{
    public class JobService
    {
        UnitOfWork unitOfWork;
        Generic<Job> JobRepo;
        public JobService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            JobRepo = unitOfWork.JobRepo;
        }
        public JobEditViewModel Add(JobEditViewModel P)
        {
            Job PP = JobRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public JobEditViewModel Update(JobEditViewModel P)
        {
            Job PP = JobRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public Job GetByID(int id)
        {
            return JobRepo.GetByID(id);
        }
       
        public IEnumerable<JobViewModel> GetAll()
        {
            var query =
                JobRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
       
        public void Remove(int id)
        {
            JobRepo.Remove(JobRepo.GetByID(id));
            unitOfWork.Commit();
        }
    }
}
