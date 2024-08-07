using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public bool IsDelivery { get; set; }
    }
}
