using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Entities
{
    public class Employee : BaseModel
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalID { get; set; }
        public int Gender { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
        public virtual Job Job { get; set; }
        public int JobID { get; set; }
    }
}
