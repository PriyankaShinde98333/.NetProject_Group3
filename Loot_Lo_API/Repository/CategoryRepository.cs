using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loot_Lo_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LootLoDbContext _context;
        public CategoryRepository(LootLoDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result = _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task PutCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }
    }
}
