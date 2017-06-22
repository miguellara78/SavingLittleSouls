//using System;
//using System.Linq;
//using System.Web.Http;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;

//// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace saving_little_souls.Controllers.api
//{
//    [RoutePrefix("api/AnimalTypes")]
//    public class AnimalTypesController : ApiController
//    {
//        private ApplicationDbContext _dbContext = new ApplicationDbContext();

//        [HttpGet]
//        public IHttpActionResult Get()
//        {
//            return Ok(
//                    from animalType in _dbContext.AnimalTypes.ToList()
//                    select new { Id = animalType.Id, Name = animalType.Name, Description = animalType.Description }
//                );
//        }

//        [HttpGet]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        [HttpPost]
//        public IHttpActionResult Post(AnimalType animalType)
//        {
//            try
//            {
//                _dbContext.AnimalTypes.Add(animalType);
//                _dbContext.SaveChanges();

//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(new Exception("There was an error on the server"));
//            }

//            return Ok();
//        }

//        [HttpPut]
//        public void Put(int id, string value)
//        {
//        }

//        [HttpDelete]
//        public void Delete(int id)
//        {
//        }
//    }
//}
