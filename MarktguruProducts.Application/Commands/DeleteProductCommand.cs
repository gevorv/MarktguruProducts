using MarktguruProducts.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; }

        public DeleteProductCommand(Guid productId)
        {
            this.ProductId = productId;
        }
    }
}
