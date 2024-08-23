using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IProductImageService 
	{
		IResult AddProductImage(ProductImageAddDto productImageAddDto);

		IDataResult<List<ProductImageToProductsDto>> GetAllProductImagesByFeatured();
	}
}
