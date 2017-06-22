using System;
using System.Linq;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace saving_little_souls.Controllers.api
{
    [RoutePrefix("api/states")]
    public class StatesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public StatesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(
                    from status in _dbContext.States.ToList()
                    select new { Id = status.Id, Name = status.Name }
                );
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost()]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
