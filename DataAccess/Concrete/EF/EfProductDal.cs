using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public EfProductDal()
        {
            _products = new List<Product>()
            {
                new (){Id=1, ProductName = "Iphone", Description="256ssd 6ram black", Price = 3456, ProductCount = 10, IsDiscount = false, DiscountRate=0},
                new (){Id=2, ProductName = "Hp Envy", Description="512ssd 32ram 360deg", Price = 7230.50m, ProductCount = 4, IsDiscount = true, DiscountRate=10},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ = > FirstOrDefault, Single, First, SingleOrDefault, Where

            Product removeProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (removeProduct != null)
                removeProduct.IsDelete = true;
            else
                throw new Exception("bele bir mehsul yoxdu");
        }

        public List<Product> GetAll()
        {
            return _products.Where(p => p.IsDelete == false).ToList();
        }

        public void Update(Product product)
        {
            Product updateProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.DiscountRate = product.DiscountRate;
                updateProduct.Price = product.Price;
            }
            else
                throw new Exception("Bele bir mehsul yoxdu");
        }
    }
}
