using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Interfaces
{
    public interface IAdminRepository
    {
        Task<ActionResult<IEnumerable<Admin>>> GetAdmins();
        Task<ActionResult<Admin>> GetAdmin(string adminEmail);
        bool Login(string adminEmail, string adminPassword);
        //Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId);
        Task<ActionResult<Admin>> PostAdmin(Admin admin);
        Task PutAdmin(int id, Admin admin);
        Task DeleteAdmin(int id);
        bool AdminExists(int id);
    }
}
