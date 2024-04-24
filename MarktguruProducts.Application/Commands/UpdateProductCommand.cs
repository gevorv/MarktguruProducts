using MarktguruProducts.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarktguruProducts.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Product Product { get; }

        public UpdateProductCommand(Product product)
        {
            this.Product = product;
        }
    }
}
