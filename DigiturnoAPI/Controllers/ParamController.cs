using Microsoft.AspNetCore.Mvc;


namespace DigiturnoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamController : ControllerBase
    {

       

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
