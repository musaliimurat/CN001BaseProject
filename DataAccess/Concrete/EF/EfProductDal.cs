using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : IProductDal
    {
        

        public EfProductDal()
        {
            
        }
        public void Add(Product product)
        {
            using(var context = new BaseProjectContext())
            {
                var addProduct = context.Entry(product);
                addProduct.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            //LINQ = > FirstOrDefault, Single, First, SingleOrDefault, Where
            using (var context = new BaseProjectContext())
            {
                var deleteProduct = context.Entry(product);
                deleteProduct.State = EntityState.Deleted;

                context.SaveChanges();
            }

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new BaseProjectContext()) 
            {
                return context.Set<Product>().ToList();
            }
        }

        public void Update(Product product)
        {
          
        }
    }
}
