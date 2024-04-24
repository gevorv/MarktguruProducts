using AutoMapper;
using MarktguruProducts.Application.Commands;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request.Product);

            await this.productRepository.UpdateProductAsync(product);

            return true;
        }
    }
}
