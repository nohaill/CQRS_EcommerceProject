using Dapper;
using Ecommerce.Domain.Dtos.Product;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = "SELECT Id, Name, Price, Stock FROM Products";
            return await db.QueryAsync<Product>(sql);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<int> CreateProductAsync(AddProduct product)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var query = @"
        INSERT INTO Products (Name, Price, Stock)
        VALUES (@Name, @Price, @Stock);
        SELECT CAST(SCOPE_IDENTITY() as int);
    ";
        
            var newId = await db.QuerySingleAsync<int>(query, product);
            return newId;
        }


        public async Task<bool> UpdateProductAsync(UpdateProduct product)
        {
            var sql = @"
        UPDATE Products
        SET Name = @Name, Price = @Price, Stock = @Stock
        WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);

            var rowsAffected = await connection.ExecuteAsync(sql, product);

            return rowsAffected > 0;
        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }

    }
}