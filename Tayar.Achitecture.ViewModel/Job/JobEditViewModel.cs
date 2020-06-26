using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.ViewModels
{
    public class JobEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [MaxLength(200)]

        public string Name { get; set; }
       
        


    }
}
