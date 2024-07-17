using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;
        public void Add(Product product)
        {
            _productDal.Add(product);

        }

        public void Delete(Product product)
        {
            Product deleteProduct = _productDal.GetAll().SingleOrDefault(p => p.Id == product.Id);
            if (deleteProduct != null)
                deleteProduct.IsDelete = true;
            _productDal.Delete(deleteProduct);
        }

        public List<Product> GetAllProduct()
        {
            return _productDal.GetAll(p => p.IsDelete == false).ToList();
        }

        public Product GetProduct(Product product)
        {

            return _productDal.Get(p => p.Id == product.Id);
        }

        public void Update(Product product)
        {
            Product updateProduct;
            updateProduct = _productDal.Get(p => p.Id == product.Id && p.IsDelete == false);
            updateProduct.ProductName = product.ProductName;
            updateProduct.ProductCount = product.ProductCount;
            updateProduct.Description = product.Description;
            updateProduct.Price = product.Price;
            _productDal.Update(product);
        }
    }
}
