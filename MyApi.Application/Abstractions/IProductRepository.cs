using MyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

// This layer defines contracts the rest of the app uses.
// The API depends on the interface, not directly on EF Core.
namespace MyApi.Application.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    } 

}
