using Core.Helpers.Results.Abstract;
using Entities.Concrete;
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
        IResult Delete( Product product );
        IDataResult<List<Product>> GetAllProduct();
        IDataResult<Product> GetProduct(Product product);
    }
}
