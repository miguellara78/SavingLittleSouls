using System;
using System.Linq;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace saving_little_souls.Controllers.api
{
    [RoutePrefix("api/pets")]
    public class PetsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public PetsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(
                    _dbContext.Pets.Select(p =>
                    new { p.Id, p.Name,Gender = p.Gender.Name,p.IdTag, p.Color, p.Age, Breed = p.Breed.Name, AnimalType = p.Breed.AnimalType.Name, ImagePath = p.PetImages.FirstOrDefault(i => i.Featured == true).ImagePath,p.Weight,p.IsAdopted})
                );
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var Id = int.Parse(id);
            var result = _dbContext.Pets.Where(p => p.Id == Id).Select(p =>
           new { p.Id, p.Name, p.IdTag, p.AdmitionDate,Status = p.Status.Name,StatusDescription = p.Status.Description, p.AdoptionDate, Breed = p.Breed.Name, p.Color, Gender = p.Gender.Name, p.Weight, p.Notes, p.Age,p.IsAdopted, AnimalType = p.Breed.AnimalType.Name, Images = p.PetImages.Select(i => i.ImagePath)})
            ;

            if (result.Count() < 1)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Pet pet)
        {
            try
            {
                _dbContext.Pets.Add(pet);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Pet pet)
        {
            int result = 0;
            try
            {
                pet.Id = id;
                _dbContext.Entry(pet).State = EntityState.Modified;
                result = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int result = 0;
            try
            {
                var pet = _dbContext.Pets.Find(id);
                if (pet != null)
                {
                    _dbContext.Entry(pet).State = EntityState.Deleted;
                    result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
