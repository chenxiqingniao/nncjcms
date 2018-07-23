using NNJC_CMS.Infrastructure;

namespace NNJC_CMS.Models.Customers
{
    public class Customer: IAggregateRoot
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
    }
}