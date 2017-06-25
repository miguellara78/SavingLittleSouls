using System;
using System.Linq;
using System.Web.Http;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace saving_little_souls.Controllers.api
{
    [RoutePrefix("api/Breeds")]
    public class BreedsController : ApiController
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(
                    from breed in _dbContext.Breeds.ToList()
                    select new { Id = breed.Id, Name = breed.Name, Description = breed.Description }
                );
        }

        // GET api/values/animaltype/5
        [HttpGet]
        public IHttpActionResult GetByAnimalType(int id)
        {
            var result = from breed in _dbContext.Breeds.ToList()
                         where breed.AnimalTypeId == id
                         select new { id = breed.Id, Name = breed.Name };
            if (result.Count() < 1)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IHttpActionResult Post([FromBody]Breed breed)
        {
            try
            {
                _dbContext.Breeds.Add(breed);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("There was an error on the server"));
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
