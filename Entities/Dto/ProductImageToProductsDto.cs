using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
	public class ProductImageToProductsDto : IDto
	{
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string CategoryName { get; set; }
        public string Description { get; set; }
		public int ProductCount { get; set; }
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
        public int ProductImageId { get; set; }
    }
}
