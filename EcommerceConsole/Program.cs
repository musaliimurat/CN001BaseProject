﻿
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Abstract;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal(new BaseProjectContext()));

Product product1 = new() { ProductName = "Hp pavilion", Description = "256ssd 16ram", IsDiscount = false, DiscountRate = 0, Price = 4567, IsDelete = false, ProductCount = 3 };
//productManager.Add(product1);

var allProducts = productManager.GetAllProduct();

//foreach (var item in allProducts)
//{
//    Console.WriteLine(item.ProductName);
//}



Console.WriteLine("test-2");

Console.WriteLine(allProducts.Message);
foreach (var product in allProducts.Data)
{
    Console.WriteLine(product.ProductName);

}
var products = productManager.GetAllProduct();

//Console.WriteLine("=====================================");
//foreach (var item in products)
//{
//    Console.WriteLine(item.ProductName);
//}


//var productGetAll = productManager.GetAllProduct();
//foreach (var product in productGetAll)
//{
//    Console.WriteLine(product.ProductName);
//}
//foreach (var item in productManager.GetAllProduct())
//{
//    if (item.Id==2)
//    {
//        productManager.Delete(item);
//    }
//}
//productManager.Delete(product1);
//CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

//Customer customer1 = new() { Id = 1, FirstName = "murad" };


//customerManager.Add(customer1);
