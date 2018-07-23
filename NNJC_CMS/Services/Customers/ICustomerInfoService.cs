using NNJC_CMS.Models.Customers;
using System.Collections.Generic;

namespace NNJC_CMS.Services.Customers
{
    public interface ICustomerInfoService
    {
        IList<Customer> GetPagedCustomers();
    }
}
