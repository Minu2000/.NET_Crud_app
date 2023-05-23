using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minunetcore.Models;
using System.Xml.Serialization;

namespace Minunetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatamodelController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            List<Datamodel> data = GenerateData();

            var serializer = new XmlSerializer(typeof(List<Datamodel>));
            var xmlString = "";
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, data);
                xmlString = stringWriter.ToString();
            }
            return Content(xmlString, "application/xml");
        }

        private List<Datamodel> GenerateData()
        {
            var data = new List<Datamodel>();

            data.Add(new Datamodel(1, "mobile"));
            data.Add(new Datamodel(2, "laptop"));
            return data;
        }
    }
}
