using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingLittleSouls.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    public class AdoptersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public AdoptersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _dbContext.Adopters.Select(a =>
                    new { a.Id, a.FirstName, a.LastName, a.City, State = a.State.Abreviation, a.Email, a.Phone, PetsCount = a.Pets.Count })
                );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
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

        [HttpPost]
        public IActionResult Post([FromBody] Adopter adopter)
        {
            
            try
            {
                _dbContext.Adopters.Add(adopter);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Adopter adopter)
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
                return new StatusCodeResult(500);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
                return new StatusCodeResult(500);
            }

            if(result > 0)
            {
                return Ok();
            }
            else
            {
                return new NotFoundResult();
            }
            

        }
    }
}
