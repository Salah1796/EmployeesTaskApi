using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Architecture.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalID { get; set; }
        public int Gender { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string  Job { get; set; }
        public int JobID { get; set; }


    }
}
