using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDRBL.DTO;
using SDRBL.Handlers;

namespace SDRWebAPI.Controllers
{
    public class ResourceController : ApiController
    {
        private FileHandler file = new FileHandler();

        // GET: api/Resource
        public ResourceListDTO Get()
        {
            return file.GetResourceList();
        }

        // GET: api/Resource/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Resource
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Resource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Resource/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                file.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
