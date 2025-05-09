using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.Vehicle;
using static api_multas.Models.Vehicle.csEstructVehicle;

namespace api_multas.Controllers
{
    public class vehicleController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertVehicle")]
        public IHttpActionResult insertVehicle(requestVehicle model)
        {
            return Ok(new csVehicle().insertVehicle(model.license_plate, model.brand, model.model, model.color, model.vehicle_type));
        }
        [HttpPut]
        [Route("rest/api/updateVehicle")]
        public IHttpActionResult updateVehicle(requestVehicle model)
        {
            return Ok(new csVehicle().updateVehicle(model.vehicle_id, model.license_plate, model.brand, model.model, model.color, model.vehicle_type));
        }
        [HttpDelete]
        [Route("rest/api/deleteVehicle")]
        public IHttpActionResult deleteVehicle(requestDeleteVehicle model)
        {
            return Ok(new csVehicle().deleteVehicle(model.vehicle_id));
        }
        [HttpGet]
        [Route("rest/api/getVehicles")]
        public IHttpActionResult getVehicles()
        {
            return Ok(new csVehicle().getVehicles());
        }
        [HttpGet]
        [Route("rest/api/getVehicleById")]
        public IHttpActionResult getVehicleById(string vehicle_id)
        {
            return Ok(new csVehicle().getVehicleById(vehicle_id));
        }
    }
}