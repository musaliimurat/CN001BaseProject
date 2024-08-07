using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailManager(IOrderDetailDal orderDetailDal) : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal = orderDetailDal;
        public IResult AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult("elave olundu!");
        }

        public IDataResult<List<OrderDetailDto>> GetAllDetailOrders()
        {
            var result = _orderDetailDal.GetAllOrderDetails();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<OrderDetailDto>>(result,"siyahi yuklendi");
            }
            else return new ErrorDataResult<List<OrderDetailDto>>(result, "xeta bash verdi");
        }
    }
}
