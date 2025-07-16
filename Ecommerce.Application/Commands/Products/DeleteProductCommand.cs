using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }

    }
}
