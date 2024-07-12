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
            if (DateTime.Now.Hour == 21)
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
            Product deleteProduct = null;
            //foreach (var item in _productDal.GetAll().)
            //{
            //    if (item.Id == product.Id)
            //    {
            //        deleteProduct = item;
            //    }

            //}
           deleteProduct =  _productDal.GetAll().SingleOrDefault(p => p.Id == product.Id);
            _productDal.Delete(deleteProduct);
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
