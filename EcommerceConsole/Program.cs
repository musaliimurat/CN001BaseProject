
using Business.Concrete;
using DataAccess.Concrete.EF;
using DataAccess.Concrete.Mongo;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());

Product product1 = new() { ProductName = "Samsung S23" };
productManager.Add(product1);

var productGetAll = productManager.GetAllProduct();
foreach (var product in productGetAll)
{
    Console.WriteLine(product.ProductName);
}

CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

Customer customer1 = new() { Id = 1, FirstName = "murad" };

customerManager.Add(customer1);

