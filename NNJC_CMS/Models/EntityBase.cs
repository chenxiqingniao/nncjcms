namespace NNJC_CMS.Models
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }
        public override bool Equals(object obj)
        {
            return obj != null && obj is EntityBase<TId> && this == (EntityBase<TId>)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}