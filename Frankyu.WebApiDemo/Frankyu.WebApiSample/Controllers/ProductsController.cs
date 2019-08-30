using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Frankyu.WebApiSample.Filter;
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

        [HttpGet]
        [ActionName("GetById")]
        public IHttpActionResult GetProduct([FromUri]int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [ActionName("NewProduct")]
        public string NewProduct([FromBody]int id)
        {
            if (id == 0)
                return "id is zero";

            var pro = products.FirstOrDefault(p => p.Id == id);
            if (pro == null)
            {
                return "you create a new product, product id is " + id;
            }

            return "the product id " + id + " is exist";
        }

        [HttpPut]
        [RequestModelFilter]
        [ActionName("UpdateProduct")]
        public string UpdateProduct([FromBody]Product product)
        {
            var pro = products.FirstOrDefault(p => p.Id == product.Id);
            if (pro == null)
                return "false";

            return "true";
        }

        [HttpDelete]
        [ActionName("DeleteProduct")]
        public string DeleteProduct([FromBody]int id)
        {
            var pro = products.FirstOrDefault(p => p.Id == id);
            if (pro == null)
                return "false";

            return "true";
        }

        [HttpGet]
        [Route("api/Test/GetDataForXML")]
        public HttpResponseMessage GetDataForXML(string date)
        {
            var response = Request.CreateResponse<List<Product>>(
                HttpStatusCode.OK,
                products.ToList(),
                Configuration.Formatters.JsonFormatter);
            return response;
        }

        [HttpGet]
        [ActionName("redicrct")]
        public IHttpActionResult RedicrctNewUrl()
        {
            return Redirect("https://www.mesince.com");
        }
    }
}
