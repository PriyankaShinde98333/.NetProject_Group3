using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Loot_Lo_API.Interfaces;
using System.Collections;

namespace Loot_Lo_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminRepository;
        public AdminController(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
             return await adminRepository.GetAdmins();
        }

        [HttpPost]
        [Route("validateAdmin")]
        public async Task<ActionResult<Admin>> Login([FromBody] ArrayList values)
        {
            if(adminRepository.Login(values[0].ToString(), values[1].ToString()))
            {
                var admin = await adminRepository.GetAdmin(values[0].ToString());
                return RedirectToAction("GetProducts", "Product");
                //return RedirectToAction("GetProductsByAdminId", new { @adminId = admin.Value.AdminId });
                //return CreatedAtAction("GetProductsByAdminId", new { @adminId = admin.Value.AdminId }, admin.Value.AdminId);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetAdmin/{adminEmail}")]
        public async Task<ActionResult<Admin>> GetAdmin(string adminEmail)
        {
            return await adminRepository.GetAdmin(adminEmail);
        }

        //[HttpGet("{adminId}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId)
        //{
        //    return await adminRepository.GetProductsByAdminId(adminId);
        //}

        //[BasicAuthentication]
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Admin>> GetAdmin(int id)
        //{
        //    var result = await adminRepository.GetAdmin(id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return result   ;
        //}

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin([FromBody] Admin admin)
        {
            try
            {
                await adminRepository.PostAdmin(admin);
            }
            catch (DbUpdateException)
            {
                if (adminRepository.AdminExists(admin.AdminId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetAdmin", new { id = admin.AdminId }, admin);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.AdminId)
            {
                return BadRequest();
            }

            try
            {
                await adminRepository.PutAdmin(id, admin);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminRepository.AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            try
            {
                await adminRepository.DeleteAdmin(id);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!adminRepository.AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}