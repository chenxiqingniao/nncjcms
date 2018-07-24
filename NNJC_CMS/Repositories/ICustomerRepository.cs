using System.Collections.Generic;
using NNJC_CMS.Models.Customers;

namespace NNJC_CMS.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        void Add(Customer customer);
        void Remove(Customer customer);
        IEnumerable<Customer> FindBy(string customerFullName);
    }
}
