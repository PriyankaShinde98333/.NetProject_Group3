using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loot_Lo_API.Models;

namespace Loot_Lo_API.Interfaces
{
    public interface IProductRepository
    {
        Task<ActionResult<IEnumerable<Product>>> GetProducts();
        Task<ActionResult<Product>> GetProduct(int id);
        //Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId);
        Task<ActionResult<Product>> PostProduct(Product product);
        Task PutProduct(int id, Product product);
        Task DeleteProduct(int id);
        bool ProductExists(int id);
    }
}
