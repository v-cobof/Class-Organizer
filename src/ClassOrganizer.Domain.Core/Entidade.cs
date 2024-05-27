namespace ClassOrganizer.Domain.Core
{
    public abstract class Entidade
    {
        public int Id { get; }

        public Entidade()
        {
        }

        public override bool Equals(object obj)
        {
            var compare = obj as Entidade;

            if (ReferenceEquals(this, compare)) return true;
            if (ReferenceEquals(null, compare)) return false;

            return Id.Equals(compare.Id);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 437 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
    }
}
