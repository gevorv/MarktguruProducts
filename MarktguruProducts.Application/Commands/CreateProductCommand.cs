using MarktguruProducts.Application.Responses;
using MarktguruProducts.Domain.Models;
using MediatR;

namespace MarktguruProducts.Application.Commands
{
    public class CreateProductCommand : IRequest<GetProductResponse>
    {
        public Product Product { get; }

        public CreateProductCommand(Product product)
        {
            this.Product = product;
        }
    }
}
