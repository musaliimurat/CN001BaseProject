using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;
        public IResult Add(Product product)
        {
            if (product.ProductName.Length > 2)
            {
                _productDal.Add(product);

                return new SuccessResult("product elave olundu");
            }
            else
                return new ErrorResult("product name lenght 2den boyuk olmalidir");

        }

        public IResult Delete(Product product)
        {
            Product deleteProduct = null;
            Product resultProduct = _productDal.Get(p=>p.IsDelete == false && p.Id == product.Id);
            if (resultProduct != null)
               deleteProduct = resultProduct;
            deleteProduct.IsDelete = true;
            _productDal.Delete(deleteProduct);
            return new SuccessResult();

        }

        public IDataResult<List<Product>> GetAllProduct()
        {
            var products = _productDal.GetAll(p => p.IsDelete == true).ToList();
            if (products.Count > 0)
                return new SuccessDataResult<List<Product>>(products);
            else return new ErrorDataResult<List<Product>>("xeta bash verdi");
        }

        public IDataResult<Product> GetProduct(Product product)
        {
            Product getProduct = _productDal.Get(p => p.Id == product.Id);


            return new SuccessDataResult<Product>(product, "get product loaded");
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
