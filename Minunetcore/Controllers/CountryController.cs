using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minunetcore.Data;
using Minunetcore.Models;

namespace Minunetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext db_context;

        public CountryController(ApplicationDbContext dbcontext) 

        {
            db_context = dbcontext;
        }
        [HttpPost]
        public ActionResult <Country> Create([FromBody]Country country)
        {
            db_context.Countries.Add(country);
            db_context.SaveChanges();
            return Ok(country);
        }

       
        [HttpGet("{id:int}")]
        public ActionResult<Country> Get(int id) {
            var country = db_context.Countries.Find(id);
            if(country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPut("{id}")]
        public ActionResult<Country> PutMethod(int id ,[FromBody]Country updatedcountry)
        {
            var country = db_context.Countries.Find(id);
            if(country == null)
            {
                return NotFound();
            }

            country.Name = updatedcountry.Name;
            db_context.SaveChanges();
            return Ok(country);
        }
        [HttpDelete("{id}")]
        public ActionResult<Country> Delete(int id) {
            var country = db_context.Countries.Find(id);
            if(country == null)
            {
                return NotFound();
            }
            db_context.Remove(country);
            db_context.SaveChanges();
            return Ok();

        }


    }
}
