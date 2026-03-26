using Microsoft.EntityFrameworkCore;
using MyApi.Application.Abstractions;
using MyApi.Domain.Entities;
using MyApi.Infrastructure.Data;

namespace MyApi.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Products
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id, cancellationToken);
        if (existing is null)
            return false;

        existing.Name = product.Name;
        existing.Price = product.Price;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (existing is null)
            return false;

        _db.Products.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}