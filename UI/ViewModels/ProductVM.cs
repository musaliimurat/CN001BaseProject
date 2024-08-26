using Entities.Concrete;
using Entities.Dto;

namespace UI.ViewModels
{
	public class ProductVM
	{
		public List<ProductImage> ProductImageGetById { get; set; }
        public Product ProductGetById { get; set; }
    }
}
