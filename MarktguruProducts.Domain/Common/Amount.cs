namespace MarktguruProducts.Domain.Common
{
	public class Amount : ValueObject
	{
		public decimal AmountValue { get; set; }

		public Amount(decimal amount)
		{
			AmountValue = amount;
		}

		protected Amount() { }

		protected override IEnumerable<object> GetAtomicValue()
		{
			yield return AmountValue;
		}

		public Amount Add(Amount amount)
		{
			return new Amount(AmountValue + amount.AmountValue);
		}

		public static implicit operator Amount(decimal value)
		{
			return new Amount(value);
		}

		public static Amount operator +(Amount amount1, Amount amount2)
		{
			return new Amount(amount1.AmountValue + amount2.AmountValue);
		}

		public static Amount operator -(Amount amount1, Amount amount2)
		{
			return new Amount(amount1.AmountValue - amount2.AmountValue);
		}

		public static bool operator <(Amount amount1, Amount amount2)
		{
			return amount1.AmountValue < amount2.AmountValue;
		}

		public static bool operator >(Amount amount1, Amount amount2)
		{
			return amount1.AmountValue > amount2.AmountValue;
		}

		public static bool operator <=(Amount amount1, Amount amount2)
		{
			return amount1.AmountValue <= amount2.AmountValue;
		}

		public static bool operator >=(Amount amount1, Amount amount2)
		{
			return amount1.AmountValue >= amount2.AmountValue;
		}
	}
}
