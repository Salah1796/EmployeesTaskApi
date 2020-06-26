using Tayar.Achitecture.Entities;
using Tayar.Architecture.Repositories;
using Tayar.Architecture.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayar.Achitecture.Services.Helpers;

namespace Tayar.Architecture.Services
{
    public class EmployeeService
    {
        UnitOfWork unitOfWork;
        Generic<Employee> EmployeeRepo;
        public EmployeeService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            EmployeeRepo = unitOfWork.EmployeeRepo;
        }
        public EmployeeEditViewModel Add(EmployeeEditViewModel P)
        {
            Employee PP = EmployeeRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public EmployeeEditViewModel Update(EmployeeEditViewModel P)
        {
            Employee PP = EmployeeRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public Employee GetByID(int id)
        {
            return EmployeeRepo.GetByID(id);
        }
       
        public IEnumerable<EmployeeViewModel> GetAll(out int Count,int PageIndex, int PageSize,string SortField, bool Ascending)
        {
            var query =
                EmployeeRepo.GetAll(out Count,PageIndex, PageSize,SortField,  Ascending);

           
            return query.ToList().Select(i => i.ToViewModel());
        }
       
        public void Remove(int id)
        {
            EmployeeRepo.Remove(EmployeeRepo.GetByID(id));
            unitOfWork.Commit();
        }

        public bool ChangeStatus(int id)
        {
            Employee Employee = GetByID(id);
            if (Employee != null)
            {
                Employee.IsActive = !Employee.IsActive;
                unitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}
