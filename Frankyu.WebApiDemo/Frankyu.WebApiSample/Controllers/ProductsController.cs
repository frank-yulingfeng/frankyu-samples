using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Frankyu.WebApiSample.Models;

namespace Frankyu.WebApiSample.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        {
            new Product
            {
                Id=1,
                Name="Tomato Soup",
                Category="Groceries",
                Price=1
            },
            new Product
            {
                Id=2,
                Name="yo-yo",
                Category="Toys",
                Price=3.75M
            },
            new Product
            {
                Id=3,
                Name="Hammer",
                Category="Hardware",
                Price=16.99M
            },
            new Product
            {
                Id=4,
                Name="Cake",
                Category="Food",
                Price=3.75M
            },
            new Product
            {
                Id=5,
                Name="Apple",
                Category="Fruit",
                Price=3.75M
            },
        };

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpPost]
        [ActionName("GetById")]
        public IHttpActionResult GetProduct([FromBody]int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
