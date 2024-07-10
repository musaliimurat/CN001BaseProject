using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //business logic
    public class CustomerManager(ICustomerDal customerDal) : ICustomerService
    {
        private readonly ICustomerDal _customerDal = customerDal;
        public void Add(Customer customer)
        {
            //business code
            if (customer.FirstName.Length >= 5)
            {
                _customerDal.Add(customer);

            }
            else
                Console.WriteLine("adlandirma qaydasi yanlisdir");
        }
    }
}
