using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNJC_CMS.Models.Customers
{
    public class CustomerInfoService : ICustomerInfoService
    {
        public IList<Customer> GetPagedCustomers()
        {
            return new List<Customer> {
                new Customer { CustomerFullName="南宁财嘉紧固件"}
            };
        }
    }
}