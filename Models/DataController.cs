using API2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace API2
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private static List<DataObject> data = new List<DataObject>();

        [HttpGet]
        public IEnumerable<DataObject> GetDataObjects()
        {
            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<DataObject> GetDataObject(int id)
        {
            var dataObject = data.FirstOrDefault(d => d.Id == id);
            if (dataObject == null)
            {
                return NotFound();
            }
            return dataObject;
        }

        [HttpPost]
        public ActionResult<DataObject> AddDataObject([FromBody] DataObject dataObject)
        {
            if (data.Any(d => d.Id == dataObject.Id))
            {
                return Conflict();
            }
            data.Add(dataObject);
            return CreatedAtAction(nameof(GetDataObject), new { id = dataObject.Id }, dataObject);
        }

        [HttpPost("application/xml")]
        public IActionResult AddDataObjectXml([FromBody] DataObject dataObject)
        {
            if (data.Any(d => d.Id == dataObject.Id))
            {
                return Conflict();
            }

            data.Add(dataObject);

            return CreatedAtAction(nameof(GetDataObject), new { id = dataObject.Id }, dataObject);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateDataObject(int id, [FromBody] DataObject dataObject)
        {
            var existingDataObject = data.FirstOrDefault(d => d.Id == id);
            if (existingDataObject == null)
            {
                return NotFound();
            }
            existingDataObject.Id = dataObject.Id;
            existingDataObject.Records = dataObject.Records;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDataObject(int id)
        {
            var dataObject = data.FirstOrDefault(d => d.Id == id);
            if (dataObject == null)
            {
                return NotFound();
            }
            data.Remove(dataObject);
            return NoContent();
        }
    }
}
