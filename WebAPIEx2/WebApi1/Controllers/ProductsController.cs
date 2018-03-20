using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Routing;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        [HttpGet]
        [Route("api/products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet]
        [Route("api/products/{name}", Name = "GetBookByName")]
        public IHttpActionResult GetProduct(string name)
        {
            var product = products.FirstOrDefault((p) => p.Name.Contains(name));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("api/products/{cat}", Name = "GetBookByCat")]
        public IHttpActionResult GetProduct2(string cat)
        {
            var product = products.FirstOrDefault((p) => p.Category.Contains(cat));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("api/products/{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        
    }
}
