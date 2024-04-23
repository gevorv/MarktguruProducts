namespace MarktguruProducts.Domain.Common
{
	public class Money
	{
		public Amount Amount { get; }
		public string Currency { get; }

		public Money(decimal amount, string currency)
		{
			if (amount < 0)
			{
				throw new ArgumentException("Amount cannot be negative.", nameof(amount));
			}

			if (string.IsNullOrWhiteSpace(currency))
			{
				throw new ArgumentException("Currency cannot be empty.", nameof(currency));
			}

			Amount = amount;
			Currency = currency.ToUpper();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			var other = (Money)obj;
			return Amount == other.Amount && Currency == other.Currency;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Amount, Currency);
		}

		public override string ToString()
		{
			return $"{Amount} {Currency}";
		}

		public static Money operator +(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
			{
				throw new InvalidOperationException("Cannot add money with different currencies.");
			}

			return new Money(money1.Amount.AmountValue + money2.Amount.AmountValue, money1.Currency);
		}

		public static Money operator -(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
			{
				throw new InvalidOperationException("Cannot subtract money with different currencies.");
			}

			return new Money(money1.Amount.AmountValue - money2.Amount.AmountValue, money1.Currency);
		}
	}
}
