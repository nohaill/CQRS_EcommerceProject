using Ecommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Queries.Products
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        [Required]
        public int Id { get; set; }
    }
}
