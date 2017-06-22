using System;
using System.Linq;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using System.Web.Http;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingLittleSouls.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/adopters")]
    public class AdoptersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AdoptersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(
                    _dbContext.Adopters.Select(a =>
                    new { a.Id, a.FirstName, a.LastName, a.City, State = a.State.Abreviation, a.Email, a.Phone, PetsCount = a.Pets.Count })
                );
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(
                    _dbContext.Adopters.Where(a => a.Id == id).Select(a =>
                    new
                    {
                        a.FirstName,
                        a.LastName,
                        a.Address,
                        a.Address2,
                        a.City,
                        State = a.StateId,
                        a.Zip,
                        a.Phone,
                        a.Fax,
                        a.Email,
                        Pets = _dbContext.Pets.Where(p => p.AdopterId == id).Select(p => new { p.Id, p.IdTag, AnimalType = p.Breed.AnimalType.Name, p.Name, Breed = p.Breed.Name, p.Color })
                    })
                );
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Adopter adopter)
        {
            
            try
            {
                _dbContext.Adopters.Add(adopter);
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
        public IHttpActionResult Put(int id,[FromBody] Adopter adopter)
        {
            int result = 0;
            try
            {
                adopter.Id = id;
                _dbContext.Entry(adopter).State = EntityState.Modified;
                result =  _dbContext.SaveChanges();
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
                var adopter = _dbContext.Adopters.Find(id);
                if (adopter != null)
                {
                    _dbContext.Entry(adopter).State = EntityState.Deleted;
                    result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if(result > 0)
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
