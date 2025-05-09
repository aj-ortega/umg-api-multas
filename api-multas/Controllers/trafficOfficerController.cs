using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.TrafficOfficer;
using static api_multas.Models.TrafficOfficer.csEstructTrafficOfficer;

/*
 {
  "officer_id": 1,
  "full_name": "Juan Pérez",
  "id_number": "ID123456789",
  "rank_level": "Sargento",
  "created_at": "2025-04-24T14:30:00"
}

*/
namespace api_multas.Controllers
{
    public class trafficOfficerController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertTrafficOfficer")]
        public IHttpActionResult insertTrafficOfficer(requestTrafficOfficer model)
        {
            return Ok(new csTrafficOfficer().insertTrafficOfficer(model.full_name, model.id_number, model.rank_level));
        }
        [HttpPut]
        [Route("rest/api/updateTrafficOfficer")]
        public IHttpActionResult updateTrafficOfficer(requestTrafficOfficer model)
        {
            return Ok(new csTrafficOfficer().updateTrafficOfficer(model.officer_id, model.full_name, model.id_number, model.rank_level));
        }
        [HttpDelete]
        [Route("rest/api/deleteTrafficOfficer")]
        public IHttpActionResult deleteTrafficOfficer(requestDeleteTrafficOfficer model)
        {
            return Ok(new csTrafficOfficer().deleteTrafficOfficer(model.officer_id));
        }
        [HttpGet]
        [Route("rest/api/getTrafficOfficers")]
        public IHttpActionResult getTrafficOfficers()
        {
            return Ok(new csTrafficOfficer().getTrafficOfficers());
        }
        [HttpGet]
        [Route("rest/api/getTrafficOfficerById")]
        public IHttpActionResult getTrafficOfficerById(string officer_id)
        {
            return Ok(new csTrafficOfficer().getTrafficOfficerById(officer_id));
        }
    }
}