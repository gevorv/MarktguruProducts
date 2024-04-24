using AutoMapper;
using MarktguruProducts.Application.Queries;
using MarktguruProducts.Application.Responses;
using MarktguruProducts.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Handlers.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this.productRepository.GetProductByIdAsync(request.ProductId);

            return product == null ? null : this.mapper.Map<GetProductResponse>(product);
        }
    }
}
