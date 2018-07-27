using NNJC_CMS.Infrastructure;
using NNJC_CMS.Models.Customers;
using NNJC_CMS.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;

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
            return _customerRepository.FindAll().ToList()
                ;
        }

        public IEnumerable<Customer> GetCustomerBy(string customerFullName)
        {
           return _customerRepository.FindBy(customerFullName);
        }
    }
}