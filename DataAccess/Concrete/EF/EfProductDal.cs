using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : BaseRepository<Product, BaseProjectContext>, IProductDal
    {
        
    }
}
