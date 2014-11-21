using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SDRBL.DTO;
using SDRBL.Handlers;

namespace SDRWebAPI.Controllers
{
    public class PropertyController : ApiController
    {
        private PropertyHandler property = new PropertyHandler();

        // GET: api/Property
        public IHttpActionResult Get()
        {
            var properties = property.GetProperties();
            if (properties == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(properties);
            
        }

        // GET: api/Property/5
        public IHttpActionResult Get(int id)
        {
            var properties = property.GetProperty(id);
            if (properties == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(properties); 
        }

        // POST: api/Property
        //[ResponseType(typeof(PropertyDataDTO))]
        public async Task<IHttpActionResult> Post(PropertyDataDTO propertyData)
            //public IHttpActionResult Post(PropertyDataDTO propertyData)
        //public void Post(PropertyDataDTO propertyData)
        //public async Task<bool> Post(PropertyDataDTO propertyData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await property.SaveProperty(propertyData);
            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);

        }

        // PUT: api/Property/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Property/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                property.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
