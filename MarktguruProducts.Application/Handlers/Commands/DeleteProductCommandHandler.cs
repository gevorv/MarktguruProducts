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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this.productRepository.GetProductByIdAsync(request.ProductId);

            if(product == null)
               return false;

            await this.productRepository.DeleteProductAsync(request.ProductId);

            return true;
        }
    }
}
