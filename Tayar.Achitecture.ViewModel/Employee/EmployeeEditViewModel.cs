using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.ViewModels
{
    public class EmployeeEditViewModel
    {
        [Required(ErrorMessage = "ID Is  Required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name Is  Required")]

        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Is  Required")]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Is  Required")]
        [RegularExpression(@"^(010|011|012)[0-9]{8}$",
         ErrorMessage = "Ivalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "NationalID Is  Required")]
        [RegularExpression(@"^((?!(0))[0-9]{14})$",
         ErrorMessage = "Ivalid National ID Number")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Gender Is  Required")]
        public int Gender { get; set; }


        [Required(ErrorMessage = "Status  Is  Required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Job  Is  Required")]
        public int JobID { get; set; }

    }
}
