using NNJC_CMS.Infrastructure;
using NNJC_CMS.Models.Customers;
using NNJC_CMS.Repositories;
using System.Collections.Generic;

namespace NNJC_CMS.Services.Customers
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;
        public CustomerInfoService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
        }

        public IList<Customer> GetPagedCustomers()
        {
            return new List<Customer> {
                new Customer { CustomerFullName="南宁财嘉紧固件"}
            };
        }
    }
}