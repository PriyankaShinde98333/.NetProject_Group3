using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loot_Lo_API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ActionResult<IEnumerable<Category>>> GetCategories();
        Task<ActionResult<Category>> GetCategory(int id);
        Task<ActionResult<Category>> PostCategory(Category category);
        Task PutCategory(int id, Category category);
        Task DeleteCategory(int id);
        bool CategoryExists(int id);
    }
}
