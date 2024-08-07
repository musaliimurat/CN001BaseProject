using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //business logic
    public class CustomerManager(ICustomerDal customerDal) : ICustomerService
    {
        private readonly ICustomerDal _customerDal = customerDal;
        public IResult Add(Customer customer)
        {
            //business code
            if (customer.FirstName.Length >= 5)
            {
                _customerDal.Add(customer);
                return new SuccessResult();

            }
            else return new ErrorResult();
        }
    }
}
