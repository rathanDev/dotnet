using Microsoft.AspNetCore.Mvc;
using OneApiProj.Models;

namespace OneApiProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Phone", Price = 699 },
            new Product { Id = 2, Name = "Laptop", Price = 1299 },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product) 
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return NoContent();
        }

    }
}
