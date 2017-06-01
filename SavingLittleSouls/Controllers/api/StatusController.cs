//using System;
//using System.Linq;
//using System.Web.Http;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;

//// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace saving_little_souls.Controllers.api
//{
//    [RoutePrefix("api/Status")]
//    public class StatusController : ApiController
//    {
//        private ApplicationDbContext _dbContext = new ApplicationDbContext();

//        [HttpGet]
//        public IHttpActionResult Get()
//        {
//            return Ok(
//                    from status in _dbContext.Status.ToList()
//                    select new { Id = status.Id, Name = status.Name, Description = status.Description }
//                );
//        }

//        // GET api/values/5
//        [HttpGet]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/values
//        [HttpPost]
//        public IHttpActionResult Post([FromBody]Status status)
//        {
//            try
//            {
//                _dbContext.Status.Add(status);
//                _dbContext.SaveChanges();

//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(new Exception("There was an error on the server"));
//            }

//            return Ok();
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
