using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.Driver;
using api_multas.Models.Sanction;
using api_multas.Models.TrafficOfficer;
using api_multas.Models.Vehicle;
using api_multas.Models.Violation;
using static api_multas.Models.Driver.csEstructDriver;
using static api_multas.Models.Sanction.csEstructSanction;
using static api_multas.Models.TrafficOfficer.csEstructTrafficOfficer;
using static api_multas.Models.Vehicle.csEstructVehicle;
using static api_multas.Models.Violation.csEstructViolation;

namespace api_multas.Controllers
{
    public class violationController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertViolation")]
        public IHttpActionResult insertViolation(insertViolation model)
        {
            Debug.WriteLine(model);
            responseSanction sanction = new csSanction().insertSanction(model.sanction.description, model.sanction.sanction_type, model.sanction.cost);
            if (sanction.response == 0) return BadRequest("sanction error: " + sanction.message);

            return Ok(new csViolation().insertViolation(model.vehicle_id, model.driver_id, sanction.sanction_id, model.officer_id));
        }
        [HttpPut]
        [Route("rest/api/updateViolation")]
        public IHttpActionResult updateViolation(requestViolation model)
        {
            return Ok(new csViolation().updateViolation(model.violation_id, model.vehicle.license_plate, model.sanction.sanction_id, model.officer.officer_id));
        }
        [HttpDelete]
        [Route("rest/api/deleteViolation")]
        public IHttpActionResult deleteViolation(requestDeleteViolation model)
        {
            return Ok(new csViolation().deleteViolation(model.violation_id));
        }


        [HttpGet]
        [Route("rest/api/getViolations")]
        public IHttpActionResult getAllViolations()
        {
            return Ok(new csViolation().getAllViolations());
        }

        [HttpGet]
        [Route("rest/api/getViolationById")]
        public IHttpActionResult getViolationById(string violation_id)
        {
            return Ok(new csViolation().getViolationById(violation_id));
        }
    }
}