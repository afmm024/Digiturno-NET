using DigiturnoAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DigiturnoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamController : ControllerBase
    {

        private readonly IParamRepository _paramRepository;

        public ParamController(IParamRepository paramRepository)
        {
            _paramRepository = paramRepository;
        }

        [HttpGet("param")]
        public async Task<ActionResult> GetParam([FromQuery] bool isHandicapped)
        {
            return Ok(await _paramRepository.GetConsecutiveAsync(isHandicapped));
        }

        [HttpPost("param")]
        public async Task<ActionResult> CreateParam()
        {
            return StatusCode(201, await _paramRepository.CreateParamAsync());
        }

        //// GET api/<ParamController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ParamController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ParamController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ParamController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
