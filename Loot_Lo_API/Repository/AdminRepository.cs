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
    public class AdminRepository : IAdminRepository
    {
        private readonly LootLoDbContext _context;
        public AdminRepository(LootLoDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<ActionResult<Admin>> GetAdmin(string adminEmail)
        {
            //int adminId =  await _context.Admins.Select(a => a.AdminId).Where(admin =>admin.AdminEmail.Equals(adminEmail));
            //var admin = await (from a in _context.Admins where a.AdminEmail == adminEmail select a.AdminId);
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminEmail == adminEmail);
        }

        //public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId)
        //{
        //    return await (from p in _context.Products where p.AdminRefId == adminId select p).ToListAsync();
        //    //return await _context.Products.FindAsync(p => p.AdminRefId == admin.AdminId);
        //}

        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            var result = _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public bool Login(string adminEmail, string adminPassword)
        {
               return _context.Admins.Any(a => a.AdminEmail.Equals(adminEmail) && a.AdminPassword == adminPassword);
        
        }

        public async Task PutAdmin(int id, Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAdmin(int id)
        {
            Admin admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
        }

        public bool AdminExists(int id)
        {
            return _context.Admins.Any(a => a.AdminId == id);
        }
    }
}
