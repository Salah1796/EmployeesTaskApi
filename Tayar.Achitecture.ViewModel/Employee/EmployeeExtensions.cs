using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayar.Achitecture.Entities;

namespace Tayar.Architecture.ViewModels
{
    public static class EmployeeExtensions
    {
        public static EmployeeViewModel ToViewModel(this Employee model)
        {
            return new EmployeeViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Phone = model.Phone,
                Date = model.Date,
                Email = model.Email,
                Gender = model.Gender,
                IsActive = model.IsActive,
                Job = model.Job.Name,
                NationalID = model.NationalID,
                JobID=model.JobID



            };
        }
        public static Employee ToModel(this EmployeeEditViewModel editModel)
        {
            return new Employee
            {
                ID = editModel.ID,
                Name = editModel.Name,
                Phone = editModel.Phone,
                Date = DateTime.Now,
                Email = editModel.Email,
                Gender = editModel.Gender,
                IsActive = editModel.IsActive,
                JobID = editModel.JobID,
                NationalID = editModel.NationalID,

            };
        }
        public static EmployeeEditViewModel ToEditableViewModel(this Employee model)
        {
            return new EmployeeEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Gender = model.Gender,
                IsActive = model.IsActive,
                JobID = model.JobID,
                NationalID = model.NationalID
               
            };
        }


    }
}
