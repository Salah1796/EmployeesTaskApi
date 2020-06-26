using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayar.Achitecture.Entities;

namespace Tayar.Architecture.ViewModels
{
    public static class JobExtensions
    {
        public static JobViewModel ToViewModel(this Job model)
        {
            return new JobViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static Job ToModel(this JobEditViewModel editModel)
        {
            return new Job
            {
                ID = editModel.ID,
                Name = editModel.Name

            };
        }
        public static JobEditViewModel ToEditableViewModel(this Job model)
        {
            return new JobEditViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }


    }
}
