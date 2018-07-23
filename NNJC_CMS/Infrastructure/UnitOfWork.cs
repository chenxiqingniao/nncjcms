using System.Collections.Generic;
using System.Transactions;

namespace NNJC_CMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntitites = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        Dictionary<IAggregateRoot, IUnitOfWorkRepository> _changedEntitites = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        Dictionary<IAggregateRoot, IUnitOfWorkRepository> _deletedEntitites = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_changedEntitites.ContainsKey(entity))
            {
                _changedEntitites.Add(entity, unitOfWorkRepository);
            }
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_addedEntitites.ContainsKey(entity))
            {
                _addedEntitites.Add(entity, unitOfWorkRepository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_deletedEntitites.ContainsKey(entity))
            {
                _deletedEntitites.Add(entity, unitOfWorkRepository);
            }
        }
        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot item in _addedEntitites.Keys)
                {
                    _addedEntitites[item].PersistCreationOf(item);
                }
                foreach (IAggregateRoot item in _deletedEntitites.Keys)
                {
                    _deletedEntitites[item].PersistDeletionOf(item);
                }
                foreach (IAggregateRoot item in _changedEntitites.Keys)
                {
                    _changedEntitites[item].PersistUpdatOf(item);
                }
                scope.Complete();
            }
        }
    }
}