using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minunetcore.Data;
using Minunetcore.Models;
using System.Xml.Serialization;

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

            var serializer = new XmlSerializer(typeof(List<Datamodel>));
            var xmlString = "";
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, data);
                xmlString = stringWriter.ToString();
            }
            return Content(xmlString, "application/xml");
        }

        
        [HttpGet("{id}")]
        public ActionResult GetById(int id) { 
            var data = _dbContext.Mydata.Find(id);
            if (data == null) { 
                return NotFound();
            }
            var serializer =new XmlSerializer(typeof(Datamodel));
            var xmlString = "";
            using(var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, data);
                xmlString = stringWriter.ToString();
            }
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
