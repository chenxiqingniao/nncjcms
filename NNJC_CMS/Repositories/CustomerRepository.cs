using NNJC_CMS.Models.Customers;
using NNJC_CMS.Infrastructure;

namespace NNJC_CMS.Repositories
{
    public class CustomerRepository : ICustomerRepository, IUnitOfWorkRepository
    {
        IUnitOfWork _unitOfWork;

        public CustomerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Customer customer)
        {
            _unitOfWork.RegisterNew(customer, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            using (var context = new NNJCDBContext())
            {
                context.Customers.Add((Customer)entity);
                context.SaveChanges();
            }
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            using (var context = new NNJCDBContext())
            {
                context.Customers.Remove((Customer)entity);
                context.SaveChanges();
            }
        }

        public void PersistUpdatOf(IAggregateRoot entity)
        {
            using (var context = new NNJCDBContext())
            {
                context.Entry<Customer>((Customer)entity).State= System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(Customer customer)
        {
            _unitOfWork.RegisterRemoved(customer, this);
        }

        public void Save(Customer customer)
        {
            _unitOfWork.RegisterAmended(customer, this);
        }
    }
}