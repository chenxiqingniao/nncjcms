﻿using NNJC_CMS.Models.Customers;
using NNJC_CMS.Infrastructure;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Customer> FindBy(string customerFullName)
        {
            using (var ctx = new NNJCDBContext())
            {
                return ctx.Customers.Where(m => m.CustomerFullName.Contains(customerFullName)).ToList();
            }
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