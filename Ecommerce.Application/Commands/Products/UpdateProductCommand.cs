using Ecommerce.Domain.Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<bool> // true = success
    {
        public UpdateProduct Product { get; set; }
    }
}
