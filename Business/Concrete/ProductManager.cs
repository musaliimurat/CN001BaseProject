using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private  readonly IProductDal _productDal = productDal;
        public void Add(Product product)
        {
            if (DateTime.Now.Hour == 20)
            {
                _productDal.Add(product);
            }
            else
            {
                Console.WriteLine("problem cixdi");
            }

        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProduct()
        {
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
