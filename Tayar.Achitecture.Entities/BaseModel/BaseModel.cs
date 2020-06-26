using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Entities
{
    public class BaseModel
    {
        public  int ID { get; set; }
        public bool IsDeleted { get; set; } = false;



    }
}
