using MarktguruProducts.Domain.Interfaces.Repositories;
using MarktguruProducts.Domain.Models;

namespace MarktguruProducts.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task CreateProductAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            Product existingProduct = await GetProductByIdAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.UpdateProduct(product.Name, product.Price, product.Available, product.Description);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _products.Remove(product);
            }
            await Task.CompletedTask;
        }
    }
}
