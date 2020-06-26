
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tayar.Achitecture.Presntation;
using Tayar.Architecture.Services;
using Tayar.Architecture.ViewModels;

namespace Tayar.Archeticture.Presentation
{

    public class EmployeeController : ApiController
    {
        EmployeeService employeeService;
        public EmployeeController(EmployeeService _employeeService)
        {
            employeeService = _employeeService;


        }
        [HttpGet]
        public ResultViewModel<IEnumerable<EmployeeViewModel>> GetAll(int PageIndex, int PageSize, string SortField, bool Ascending)
        {
            ResultViewModel<IEnumerable<EmployeeViewModel>> result
                 = new ResultViewModel<IEnumerable<EmployeeViewModel>>();
            int Count;
            result.Data = employeeService.GetAll(out Count, PageIndex, PageSize, SortField, Ascending); ;
            result.Count = Count;
            result.Successed = true;
            return result;
        }
        [HttpGet]
        public ResultViewModel<EmployeeViewModel> GetByID(int id)
        {
            ResultViewModel<EmployeeViewModel> result
                = new ResultViewModel<EmployeeViewModel>();
            
            result.Data = employeeService.GetByID(id)?.ToViewModel();
            if (result.Data == null)
                result.Message = "Employee Not Found !";
            result.Successed = true;

            return result;
        }
        [HttpGet]
        public ResultViewModel<EmployeeViewModel> Delete(string EmpIDs)
        {
            List<int> DeletedEmpIDs = EmpIDs.Split(',').Select(i => int.Parse(i)).ToList();
            ResultViewModel<EmployeeViewModel> result
                = new ResultViewModel<EmployeeViewModel>();
            foreach (int id in DeletedEmpIDs)
            {
                if (employeeService.GetByID(id) != null)
                {
                    employeeService.Remove(id);
                }
            }
            result.Successed = true;
            result.Message = "Employees Deleted Sucessfully";
            return result;
        }

        [HttpPost]
        public ResultViewModel<EmployeeEditViewModel> Update(EmployeeEditViewModel emp)
        {
            ResultViewModel<EmployeeEditViewModel> result
                = new ResultViewModel<EmployeeEditViewModel>();

            if (emp == null || !ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        if (string.IsNullOrEmpty(error.ErrorMessage))
                            result.Message += " ID Is Required , ";
                        else
                            result.Message += error.ErrorMessage + " , ";
                    }
                }
            }
            else
            {
                EmployeeEditViewModel selectedEmp
                    = employeeService.Update(emp);

                result.Successed = true;
                result.Data = selectedEmp;
            }
            return result;
        }

        [HttpPost]
        public ResultViewModel<EmployeeEditViewModel> Add(EmployeeEditViewModel emp)
        {
            ResultViewModel<EmployeeEditViewModel> result
                = new ResultViewModel<EmployeeEditViewModel>();

                if (emp == null || !ModelState.IsValid)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            if (string.IsNullOrEmpty(error.ErrorMessage))
                                result.Message += " ID Is Required ";
                            else
                                result.Message += error.ErrorMessage + " , ";
                        }
                    }
                }
                else
                {
                    //Values.Errors.ErrorMessage
                    EmployeeEditViewModel selectedEmp
                        = employeeService.Add(emp);

                    result.Successed = true;
                    result.Data = selectedEmp;
               }
            return result;
        }

        [HttpGet]
        public ResultViewModel<EmployeeViewModel> ChangeStatus(int id)
        {

            ResultViewModel<EmployeeViewModel> result
                = new ResultViewModel<EmployeeViewModel>();

            if (employeeService.ChangeStatus(id))
            {
                result.Successed = true;
                result.Message = "Status Updated Sucessfully";
            }

            else
            {
                result.Successed = false;
                result.Message = "Employee Not Found";

            }
            return result;
        }


    }
}











