using Business.Abstract;
using Business.BusinessAspect.Autofac.Secured;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.CrossCuttingConcern.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService 
    {
        private readonly IProductDal _productDal = productDal;

        //AOP => Aspect Oriented Programming
        // Ioc Container
        //interception => Cross Cutting Concern => Authoritaion, Cache,log, optimizasion, Exception handlig
        //[SecuredOperation("admin,superadmin, product.add")]]

        [SecuredAspect("Admin,Moderator")]
        [ValidationAspect<Product>(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
                _productDal.Add(product);
                return new SuccessResult("product elave olundu");
        }

        public IResult Delete(int id)
        {
            Product deleteProduct = null;
            Product resultProduct = _productDal.Get(p => p.IsDelete == false && p.Id == id);
            if (resultProduct != null)
                deleteProduct = resultProduct;
            deleteProduct.IsDelete = true;
            _productDal.Delete(deleteProduct);
            return new SuccessResult();

        }

        public IDataResult<List<Product>> GetAllProduct()
        {
            var products = _productDal.GetAll(p => p.IsDelete == false).ToList();
            if (products.Count > 0)
                return new SuccessDataResult<List<Product>>(products);
            else return new ErrorDataResult<List<Product>>("xeta bash verdi");
        }

        public IDataResult<List<ProductDto>> GetAllProductByCategory(int categoryId)
        {
            var result = _productDal.GetAllProductsByCategory(categoryId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ProductDto>>(result, "siyahi yuklendi");
            }
            else return new ErrorDataResult<List<ProductDto>>(result, "xeta bash verdi");
        }

        public IDataResult<Product> GetProduct(int id)
        {
            Product getProduct = _productDal.Get(p => p.Id == id);

            if (getProduct != null)
                return new SuccessDataResult<Product>(getProduct, "get product loaded");
            else return new ErrorDataResult<Product>(getProduct, "mehsul tapilmadi");
        }

        public IResult Update(Product product)
        {
            Product updateProduct;
            updateProduct = _productDal.Get(p => p.Id == product.Id && p.IsDelete == false);
            updateProduct.ProductName = product.ProductName;
            updateProduct.ProductCount = product.ProductCount;
            updateProduct.Description = product.Description;
            updateProduct.Price = product.Price;
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
