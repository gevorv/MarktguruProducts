namespace MarktguruProducts.Domain.Common
{
	public abstract class ValueObject : IEquatable<ValueObject>
	{
		protected abstract IEnumerable<object> GetAtomicValue();

		public override int GetHashCode() =>
			GetAtomicValue()
				.Aggregate(
					default(int),
					HashCode.Combine);

		public ValueObject GetCopy() =>
			MemberwiseClone() as ValueObject ?? throw new InvalidOperationException("Failed to clone object.");

		public bool Equals(ValueObject? obj) =>
			obj is not null && GetAtomicValue().SequenceEqual(obj.GetAtomicValue());


		protected static bool EqualOperator(ValueObject left, ValueObject right)
		{
			if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
			{
				return false;
			}

			return ReferenceEquals(left, null) || left.Equals(right);
		}

		protected static bool NotEqualOperator(ValueObject left, ValueObject right)
		{
			return !EqualOperator(left, right);
		}
	}
}
