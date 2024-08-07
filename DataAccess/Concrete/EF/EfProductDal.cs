using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : BaseRepository<Product, BaseProjectContext> , IProductDal   
    {
        public EfProductDal(BaseProjectContext context) : base(context) 
        {
            
        }

        public List<ProductDto> GetAllProductsByCategory(int  categoryId)
        {
            var context = new BaseProjectContext();

            var result = from P in context.Products
                         where P.IsDelete == false && P.CategoryId == categoryId
                         join c in context.Categories
                         on P.CategoryId equals c.Id
                         select new ProductDto
                         {
                             ProductId = P.Id,
                             CategoryId = c.Id,
                             ProductName = P.ProductName,
                             ProductPrice = P.Price,
                             CategoryName = c.CategoryName
                         };
                         return result.ToList();

        }
    }
}
