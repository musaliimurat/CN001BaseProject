using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult AddOrder(Order order);
        IResult DeleteOrder(int id);
        IDataResult<Order> GetOrder(int id);
        IDataResult<List<Order>> GetAllOrders();

    }
}
