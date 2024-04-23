using MarktguruProducts.Domain.Common;

namespace MarktguruProducts.Domain.Models
{
	public class Product : Entity
	{
		public string Name { get; private set; }
		public Money Price { get; private set; }
		public bool Available { get; private set; }
		public string Description { get; private set; }

		private Product() { }

		public Product(string name, Money price, bool available, string description)
		{
			this.ValidateProduct(name, price, description);

			this.Name = name;
			this.Price = price;
			this.Available = available;
			this.Description = description;
		}

		public void UpdateProduct(string name, Money price, bool available, string description)
		{
			this.ValidateProduct(name, price, description);

			this.Name = name;
			this.Price = price;
			this.Available = available;
			this.Description = description;
		}

		private void ValidateProduct(string name, Money price, string description)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Name cannot be empty.", nameof(name));
			if (price == null)
				throw new ArgumentNullException(nameof(price));
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException("Description cannot be empty.", nameof(description));
		}
	}
}
