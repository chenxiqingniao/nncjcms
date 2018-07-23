using NNJC_CMS.Models.Customers;

namespace NNJC_CMS.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        void Add(Customer customer);
        void Remove(Customer customer);
    }
}
