namespace NNJC_CMS.Infrastructure
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(IAggregateRoot entity);
        void PersistUpdatOf(IAggregateRoot entity);
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
