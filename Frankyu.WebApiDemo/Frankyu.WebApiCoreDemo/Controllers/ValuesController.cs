
using System.Collections.Generic;
using Frankyu.WebApiCoreDemo.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace Frankyu.WebApiCoreDemo.Controllers
{
    /// <summary>
    /// 处理Value接口
    /// </summary>    
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        /// <summary>
        /// 获取所有Values
        /// </summary>
        /// <returns>Values List</returns>
        [HttpGet]
        [Route("GetAll")]
        [ApiVersions(ApiVersions.v2)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return stringList;
        }

        /// <summary>
        /// 通过id 获取对应的值
        /// </summary>        
        /// <param name="id">值ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= stringList.Count)
                return "NOT FOUND";

            return stringList[id];
        }

        /// <summary>
        /// 通过id 获取对应的值
        /// </summary>        
        /// <param name="id">值ID</param>
        /// <returns></returns>
        [HttpGet]
        [VersionRoute(ApiVersions.v2, "GetById")]
        public ActionResult<string> GetV2(int id)
        {
            if (id < 0 || id >= stringList.Count)
                return "NOT FOUND";

            return stringList[id];
        }

        /// <summary>
        /// 添加新的Value
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "value": "what the fuck",
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>        
        [HttpPost]
        [Route("New")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] string value)
        {
            stringList.Add(value);
        }

        /// <summary>
        /// 添加新的Value
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [VersionRoute(ApiVersions.v2, "PostNewValue")]       
        public void PostNewValue([FromBody] string value)
        {
            stringList.Add(value);
        }

        /// <summary>
        /// 通过Id 更新Value
        /// </summary>
        /// <param name="id">值ID</param>
        /// <param name="value">值</param>
        [HttpPut]
        [Route("Update")]
        public void Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= stringList.Count || string.IsNullOrEmpty(value))
                return;

            stringList[id] = value;
        }      

        /// <summary>
        /// 通过ID删除Value
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [VersionRoute(ApiVersions.v2, "Delete")]
        public void DeleteV2(int id)
        {
            if (id < 0 || id >= stringList.Count)
                return;

            stringList.RemoveAt(id);
        }
    }
}
