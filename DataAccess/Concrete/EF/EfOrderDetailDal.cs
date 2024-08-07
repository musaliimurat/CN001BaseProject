using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Concrete.EF
{
    public class EfOrderDetailDal : BaseRepository<OrderDetail, BaseProjectContext>, IOrderDetailDal
    {
        public EfOrderDetailDal(BaseProjectContext context) : base(context)
        {

        }
        public List<OrderDetailDto> GetAllOrderDetails()
        {
            var context = new BaseProjectContext();
            var result = from d in context.OrderDetails
                         where d.IsDelete == false
                         join o in context.Orders
                         on d.OrderId equals o.Id
                         join p in context.Products
                         on d.ProductId equals p.Id
                         select new OrderDetailDto()
                         {
                             OrderId = o.Id,
                             OrderDate = o.OrderDate,
                             IsDelivery = o.IsDelivery,
                             ProductName = p.ProductName,
                             ProductPrice = p.Price,
                             TotalPrice = d.TotalPrice,
                             DiscountPriceRate = d.DiscountPriceRate,
                             IsDisCount = d.IsDisCount,
                             Count = d.Count,


                         };
                         return result.ToList();


        }
    }
}
