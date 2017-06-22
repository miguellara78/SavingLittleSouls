//using System;
//using System.Linq;
//using System.Web.Http;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;

//// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace saving_little_souls.Controllers.api
//{
//    [RoutePrefix("api/AnimalFamilies")]
//    public class AnimalFamiliesController : ApiController
//    {
//        private ApplicationDbContext _dbContext = new ApplicationDbContext();

//        [HttpGet]
//        public IHttpActionResult Get()
//        {

//            var object1 = from animalFamily in _dbContext.AnimalFamilies.ToList()
//                          select new { Id = animalFamily.Id, Name = animalFamily.Name, Description = animalFamily.Description };
//            return Ok(object1);
//        }

//        // GET api/values/5
//        [HttpGet]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/values
//        [HttpPost]
//        public IHttpActionResult Post(AnimalFamily animalFamily)
//        {
//            try
//            {
//                _dbContext.AnimalFamilies.Add(animalFamily);
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
//        public void Put(int id, string value)
//        {
//        }

//        // DELETE api/values/5
//        [HttpDelete]
//        public void Delete(int id)
//        {
//        }
//    }
//}
