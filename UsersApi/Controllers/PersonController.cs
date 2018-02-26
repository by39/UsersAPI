using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public ArrayList  Get()
        {
            PersonPerSisstance pp = new PersonPerSisstance();
            return pp.getPeople();
        }

        // GET: api/Person/5
        public Person Get(long id)
        {
            PersonPerSisstance pp = new PersonPerSisstance();
            Person person = pp.getPerson(id);

            return person;
            //return "Some persons";
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonPerSisstance pp = new PersonPerSisstance();
            long id;

            id = pp.savePerson(value);

            value.id = id;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("person/{0}",id));
            return response;
        }

        // PUT: api/Person/5
        public HttpResponseMessage Put(long id, [FromBody]Person value)
        {
            PersonPerSisstance pp = new PersonPerSisstance();

            bool isIn = false;

            isIn = pp.putPerson(id,value);

            HttpResponseMessage response;

            if (isIn)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
        
        // DELETE: api/Person/5
        public HttpResponseMessage Delete(long id)
        {
            PersonPerSisstance pp = new PersonPerSisstance();

            bool isIn = false;

            isIn = pp.deletePerson(id);

            HttpResponseMessage response;

            if (isIn)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }
    }
}
