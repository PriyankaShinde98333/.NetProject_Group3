using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly LootLoDbContext _context;
        public ProductRepository(LootLoDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        //public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId)
        //{
        //    return await (from p in _context.Products where p.AdminRefId == adminId select p).ToListAsync();
        //    //return await _context.Products.FindAsync(p => p.AdminRefId == admin.AdminId);
        //}

        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result = _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task PutProduct(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }
    }
}
