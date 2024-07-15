
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Abstract;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());

Product product1 = new() { ProductName = "Samsung S23", Description="256ssd 16ram", IsDiscount = false, DiscountRate = 0, Price=4567, IsDelete=false  };
//productManager.Add(product1);

//productManager.Delete(product1);

//var productGetAll = productManager.GetAllProduct();
//foreach (var product in productGetAll)
//{
//    Console.WriteLine(product.ProductName);
//}
foreach (var item in productManager.GetAllProduct())
{
    if (item.Id==2)
    {
        productManager.Delete(item);
    }
}
productManager.Delete(product1);
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

Customer customer1 = new() { Id = 1, FirstName = "murad" };

customerManager.Add(customer1);

