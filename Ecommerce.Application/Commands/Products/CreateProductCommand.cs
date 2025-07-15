using Ecommerce.Domain.Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<int>  // returning new product Id
    {
        public AddProduct Product { get; set; }

    }
}
