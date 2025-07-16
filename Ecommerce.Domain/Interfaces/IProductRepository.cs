using Ecommerce.Domain.Dtos.Product;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task<int> CreateProductAsync(AddProduct product);

        Task<bool> UpdateProductAsync(UpdateProduct product);

        Task<bool> DeleteProductAsync(int id);


    }
}
