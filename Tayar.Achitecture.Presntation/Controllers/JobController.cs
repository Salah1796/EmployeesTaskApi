
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tayar.Architecture.Services;
using Tayar.Architecture.ViewModels;

namespace Tayar.Archeticture.Presentation
{

    public class JobController : ApiController
    {
        JobService JobService;
        public JobController(JobService _JobService)
        {
            JobService = _JobService;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<JobViewModel>> GetAll()
        {
            ResultViewModel<IEnumerable<JobViewModel>> result
                 = new ResultViewModel<IEnumerable<JobViewModel>>();
            result.Successed = true;
            result.Data = JobService.GetAll();
            return result;
        }
        [HttpGet]
        public ResultViewModel<JobViewModel> GetByID(int id)
        {
            ResultViewModel<JobViewModel> result
                = new ResultViewModel<JobViewModel>();
            result.Successed = true;
            result.Data = JobService.GetByID(id)?.ToViewModel();
            if (result.Data == null)
                result.Message = "Job Not Found !";

            return result;
        }
        [HttpGet]
        public ResultViewModel<JobViewModel> Delete(int id)
        {
            ResultViewModel<JobViewModel> result
                = new ResultViewModel<JobViewModel>();
            if (JobService.GetByID(id) != null)
            {
                JobService.Remove(id);
                result.Successed = true;
                result.Message = "Job Deleted Sucessfully";
            }
            else
            {
                result.Successed = false;
                result.Message = "Job Not Found !";
            }
            return result;

        }

        [HttpPost]
        public ResultViewModel<JobEditViewModel> Update(JobEditViewModel emp)
        {
            ResultViewModel<JobEditViewModel> result
                = new ResultViewModel<JobEditViewModel>();
            if (!ModelState.IsValid)
            {
                result.Message = "In Valid Model State";
            }
            else
            {
                JobEditViewModel selectedEmp
                    = JobService.Update(emp);

                result.Successed = true;
                result.Data = selectedEmp;
            }

            return result;
        }

        [HttpPost]
        public ResultViewModel<JobEditViewModel> Add(JobEditViewModel emp)
        {
            ResultViewModel<JobEditViewModel> result
                = new ResultViewModel<JobEditViewModel>();

            if (!ModelState.IsValid)
            {
                result.Message = "In Valid Model State";
            }
            else
            {
                JobEditViewModel selectedEmp
                    = JobService.Add(emp);

                result.Successed = true;
                result.Data = selectedEmp;
            }

            return result;
        }
    }
}











