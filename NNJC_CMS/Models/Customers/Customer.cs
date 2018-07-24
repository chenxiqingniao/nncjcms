using NNJC_CMS.Infrastructure;

namespace NNJC_CMS.Models.Customers
{
    public class Customer: EntityBase<int>, IAggregateRoot
    {
        public string CustomerFullName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}