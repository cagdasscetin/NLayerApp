using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            // Eager loading - ilk product çekildiğinde kategori de çekilirse bu eager loading olur
            // Lazy loading - eğer product a bağlı kategoriyi ihtiyaç olduğunda sonra çekersek lazy loading olur 
            return await _context.Products.Include(x => x.Category).ToListAsync(); //eager loading

        }
    }
}
