using AutoMapper;
using MarktguruProducts.Application.Commands;
using MarktguruProducts.Application.Responses;
using MarktguruProducts.Domain.Interfaces.Repositories;
using MarktguruProducts.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GetProductResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request.Product);

            await this.productRepository.CreateProductAsync(product);

            return this.mapper.Map<GetProductResponse>(product);
        }
    }
}
