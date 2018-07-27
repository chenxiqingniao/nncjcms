using NNJC_CMS.Models.Customers;
using System.Data.Entity;

namespace NNJC_CMS.Repositories
{
    public class NNCJDBContext:DbContext
    {
        public NNCJDBContext():base("name=nncjdb") { }
        public DbSet<Customer> Customers { get; set; }
    }
}