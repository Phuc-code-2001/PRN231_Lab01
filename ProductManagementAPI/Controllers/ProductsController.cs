using BusinessObjects.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return _productRepository.GetProducts();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            try
            {
                _productRepository.SaveProduct(p);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var p = _productRepository.GetProductById(id);
                if(p == null)
                {
                    return NotFound();
                }

                _productRepository.DeleteProduct(p);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            try
            {
                var pTmp = _productRepository.GetProductById(id);
                if (pTmp == null) return NotFound();
                if (p.Id != id) return BadRequest("Ngu truyen sai id r.");
                _productRepository.UpdateProduct(p);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
