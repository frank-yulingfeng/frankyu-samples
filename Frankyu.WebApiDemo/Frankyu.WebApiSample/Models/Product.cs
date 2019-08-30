using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Frankyu.WebApiSample.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} 必须填写")]
        public string Name { get; set; }

        public string Category { get; set; }

        [Range(typeof(decimal), "0", "10000", ErrorMessage = "{0}数值不在范围内")]
        public decimal Price { get; set; }
    }
}