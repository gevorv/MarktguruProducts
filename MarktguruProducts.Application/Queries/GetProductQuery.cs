using MarktguruProducts.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Queries
{
    public class GetProductQuery : IRequest<GetProductResponse>
    {
        public Guid ProductId { get; }

        public GetProductQuery(Guid productId)
        { 
            this.ProductId = productId;
        }
    }
}
