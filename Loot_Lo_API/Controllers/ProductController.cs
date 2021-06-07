using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Loot_Lo_API.Interfaces;

namespace Loot_Lo_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await productRepository.GetProducts();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = await productRepository.GetProduct(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
            
        }

        //[HttpGet("{adminId}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAdminId(int adminId)
        //{
        //    return await productRepository.GetProductsByAdminId(adminId);
        //}

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            try
            {
                var PostProduct = await productRepository.PostProduct(product);
            }
            catch (DbUpdateException)
            {
                if (productRepository.ProductExists(product.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("GetProducts");
            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                await productRepository.PutProduct(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productRepository.ProductExists(id))
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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productRepository.DeleteProduct(id);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!productRepository.ProductExists(id))
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