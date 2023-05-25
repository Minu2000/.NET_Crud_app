using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minunetcore.Data;
using Minunetcore.Models;
using System.Xml.Serialization;
using Minunetcore.Helpers;
namespace Minunetcore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DatamodelController : ControllerBase
    {
        private readonly DataDbContext _dbContext;  

        public DatamodelController(DataDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Datamodel> data = FetchDataFromDatabase();

            var xmlString = XmlSerializationHelper.SerializeToXml(data);
            return Content(xmlString, "application/xml");
        }

        
        [HttpGet("{id}")]
        public ActionResult GetById(int id) { 
            var data = _dbContext.Mydata.Find(id);
            if (data == null) { 
                return NotFound();
            }
            var xmlString = XmlSerializationHelper.SerializeToXml(data);
            return Content(xmlString, "application/xml");
        }


        [HttpPost]
        public ActionResult Post([FromBody] Datamodel newdata)
        {
            if(newdata == null)
            {
                return BadRequest();
            }
            _dbContext.Mydata.Add(newdata);
            _dbContext.SaveChanges();
            return Ok(newdata);
        }
        private List<Datamodel> FetchDataFromDatabase()
        {
            List<Datamodel> data =_dbContext.Mydata.ToList();
            return data;
        }
    }
}
