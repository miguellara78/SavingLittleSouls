//using System;
//using System.Linq;
//using System.Web.Http;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;

//// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace saving_little_souls.Controllers.api
//{
//    [RoutePrefix("api/Pets")]
//    public class PetsController : ApiController
//    {
//        private ApplicationDbContext _dbContext = new ApplicationDbContext();

//        [HttpGet]
//        public IHttpActionResult GetAll()
//        {
//            return Ok(
//                    from pet in _dbContext.Pets.Include("Breed").Include("Breed.AnimalType").ToList()
//                    select new { Id = pet.Id, Name = pet.Name, Color = pet.Color, Age = pet.Age, Breed = pet.Breed.Name, AnimalType = pet.Breed.AnimalType.Name }
//                );
//        }
        
//        [HttpGet]
//        public IHttpActionResult GetById(string id)
//        {
//            var Id = int.Parse(id);
//            var result = _dbContext.Pets.Where(p => p.Id == Id).Select( p =>
//            new { p.Id ,p.Name, p.IdTag,p.AdmitionDate,p.AdoptionDate,Breed = p.Breed.Name,p.Color,Gender = p.Gender.Name,p.Weight,p.Notes,p.Age})
//            ;

//            if(result.Count() < 1)
//            {
//                return NotFound();
//            }
//            return Ok( result);
//        }



//        [HttpPost]
//        public IHttpActionResult Post([FromBody]Pet pet)
//        {
//            try
//            {
//                _dbContext.Pets.Add(pet);
//                _dbContext.SaveChanges();
               
//            }
//            catch(Exception ex)
//            {
//                return InternalServerError(new Exception("There was an error on the server"));
//            }

//            return Ok();
//        }

//        [HttpPut]
//        public IHttpActionResult Update(string id, [FromBody] Pet pet)
//        {
//            return Ok(new
//            {
//                Message = "The pet wit id: " + id + " was updated successfully"
//            });
//        }

//        [HttpDelete]
//        public IHttpActionResult Delete(string id)
//        {
//            return Ok(new
//            {
//                Message = "The pet wit id: " + id + " was Deleted successfully"
//            });
//        }
//    }
//}
