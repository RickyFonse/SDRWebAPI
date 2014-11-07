﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDRBL.DTO;
using SDRBL.Handlers;

namespace SDRWebAPI.Controllers
{
    public class PropertyController : ApiController
    {
        private PropertyHandler property = new PropertyHandler();

        // GET: api/Property
        public IEnumerable<PropertyListDataDTO> Get()
        {
            return property.GetProperties();
        }

        // GET: api/Property/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Property
        public void Post([FromBody]string value)
        {
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
