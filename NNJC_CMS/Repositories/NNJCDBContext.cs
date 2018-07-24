using NNJC_CMS.Models.Customers;
using System.Data.Entity;

namespace NNJC_CMS.Repositories
{
    public class NNJCDBContext:DbContext
    {
        public NNJCDBContext():base("nncjdb") { }
        public DbSet<Customer> Customers { get; set; }
    }
}