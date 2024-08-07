using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product );
        IResult Update( Product product );
        IResult Delete( int id );
        IDataResult<List<Product>> GetAllProduct();
        IDataResult<Product> GetProduct(int id);
        IDataResult<List<ProductDto>> GetAllProductByCategory(int categoryId);
    }
}
