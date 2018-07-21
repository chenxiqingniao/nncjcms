using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNJC_CMS.Models.Customers
{
    public interface ICustomerInfoService
    {
        IList<Customer> GetPagedCustomers();
    }
}
