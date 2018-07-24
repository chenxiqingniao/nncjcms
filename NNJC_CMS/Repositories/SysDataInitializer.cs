using NNJC_CMS.Models.Customers;
using System.Collections.Generic;
using System.Data.Entity;

namespace NNJC_CMS.Repositories
{
    public class SysDataInitializer : DropCreateDatabaseIfModelChanges<NNJCDBContext>
    {
        protected override void Seed(NNJCDBContext context)
        {
            context.Customers.AddRange(new List<Customer> { new Customer { CustomerFullName = "云南富阳", Address = "云南省富阳县" }, new Customer { CustomerFullName = "南糖", Address = "广西南宁市" } });
            context.SaveChanges();
        }
    }
}