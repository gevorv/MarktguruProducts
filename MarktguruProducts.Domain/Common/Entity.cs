namespace MarktguruProducts.Domain.Common
{
	public abstract class Entity
	{
		public Guid Id { get; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }

		protected Entity()
		{
			this.Id = Guid.NewGuid();
			this.DateCreated = DateTime.UtcNow;
			this.DateUpdated = DateTime.UtcNow;
		}

		protected Entity(Guid id)
		{
			this.Id = id;
			this.DateCreated = DateTime.UtcNow;
			this.DateUpdated = DateTime.UtcNow;
		}

		protected Entity(Guid id, DateTime dateCreated, DateTime? dateUpdated)
		{
			this.Id = id;
			this.DateCreated = dateCreated;
			this.DateUpdated = dateUpdated;
		}

		public override bool Equals(object? obj)
		{
			var compareTo = obj as Entity;

			if (ReferenceEquals(this, compareTo))
			{
				return true;
			}

			if (ReferenceEquals(null, compareTo))
			{
				return false;
			}

			return Id.Equals(compareTo.Id);
		}

		public static bool operator ==(Entity a, Entity? b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
			{
				return true;
			}

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}

			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b) => !(a == b);

		public override string ToString()
		{
			return $"{GetType().Name} [Id={Id}]";
		}

		public override int GetHashCode()
		{
			return (GetType().GetHashCode() * 909) + Id.GetHashCode();
		}
	}
}
