using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Frankyu.WebApiCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> stringList = new List<string>
        {
            "value1",
            "value2",
            "value3",
            "value4",
            "value5",
            "value6",
        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return stringList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= stringList.Count)
                return "NOT FOUND";

            return stringList[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            stringList.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= stringList.Count || string.IsNullOrEmpty(value))
                return;

            stringList[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id < 0 || id >= stringList.Count)
                return;

            stringList.RemoveAt(id);
        }
    }
}
