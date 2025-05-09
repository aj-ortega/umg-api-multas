using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.Driver;
using static api_multas.Models.Driver.csEstructDriver;

namespace api_multas.Controllers
{
    public class driverController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertDriver")]
        public IHttpActionResult insertDriver(requestDriver model)
        {
            return Ok(new csDriver().insertDriver(model.full_name, model.id_number, model.address, model.phone, model.license_number));
        }
        [HttpPut]
        [Route("rest/api/updateDriver")]
        public IHttpActionResult updateDriver(requestDriver model)
        {
            return Ok(new csDriver().updateDriver(model.driver_id, model.full_name, model.id_number, model.address, model.phone, model.license_number));
        }
        [HttpDelete]
        [Route("rest/api/deleteDriver")]
        public IHttpActionResult deleteDriver(requestDeleteDriver model)
        {
            return Ok(new csDriver().deleteDriver(model.driver_id));
        }
        [HttpGet]
        [Route("rest/api/getDrivers")]
        public IHttpActionResult getDrivers()
        {
            return Ok(new csDriver().getDrivers());
        }
        [HttpGet]
        [Route("rest/api/getDriverById")]
        public IHttpActionResult getDriverById(string driver_id)
        {
            return Ok(new csDriver().getDriverById(driver_id));
        }
    }
}