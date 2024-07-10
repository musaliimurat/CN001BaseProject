using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mongo
{
    public class MongoProductDal : IProductDal
    {
        List<Product> products;
        public MongoProductDal()
        {
            products = new List<Product>();
        }
        public void Add(Product product)
        {
           products.Add(product);
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
