using Business.Abstract;
using Core.Helpers.Business;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductImageManager(IProductImageDal productImageDal, IAddPhotoHelperService addPhotoHelperService) : IProductImageService
	{
		private readonly IProductImageDal _productImageDal = productImageDal;
		private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;
		public IResult AddProductImage(ProductImageAddDto productImageAddDto)
		{
			var guid = Guid.NewGuid() + "-" + productImageAddDto.Photo.FileName;
			_addPhotoHelperService.AddImage(productImageAddDto.Photo, guid);
			ProductImage productImage = new()
			{
				ProductId = productImageAddDto.ProductId,
				PhotoUrl = "/images/" + guid,
			};
			_productImageDal.Add(productImage);
			return new SuccessResult("Elave olundu");
		}

		public IDataResult<List<ProductImageToProductsDto>> GetAllProductImagesByFeatured()
		{
			var result = _productImageDal.GetAllProductsByFeatured();
            if (result.Count>0)
            {
				return new SuccessDataResult<List<ProductImageToProductsDto>>(result);
            }
			else return new ErrorDataResult<List<ProductImageToProductsDto>>(result);
		}
	}
}
