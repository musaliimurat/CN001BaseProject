using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
       
    }
}
