//using System;
//using System.Linq;
//using System.Web.Http;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;

//// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace saving_little_souls.Controllers.api
//{
//    [RoutePrefix("api/Gender")]
//    public class GendersController : ApiController
//    {
//        private ApplicationDbContext _dbContext = new ApplicationDbContext();
//        // GET: api/values
//        [HttpGet]
//        public IHttpActionResult Get()
//        {
//            return Ok(
//                   from gender in _dbContext.Genders.ToList()
//                   select new { Id = gender.Id, Name = gender.Name }
//               );
//        }

//        // GET api/values/5
//        [HttpGet]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/values
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/values/5
//        [HttpPut]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/values/5
//        [HttpDelete]
//        public void Delete(int id)
//        {
//        }
//    }
//}
