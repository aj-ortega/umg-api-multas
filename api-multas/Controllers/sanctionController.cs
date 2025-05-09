using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.Sanction;
using static api_multas.Models.Sanction.csEstructSanction;

namespace api_multas.Controllers
{
    public class sanctionController : ApiController
    {

        [HttpPost]
        [Route("rest/api/insertSanction")]
        public IHttpActionResult insertSanction(requestSanction model)
        {
            return Ok(new csSanction().insertSanction(model.description, model.sanction_type, model.cost));
        }

        [HttpPut]
        [Route("rest/api/updateSanction")]
        public IHttpActionResult updateSanction(requestSanction model)
        {
            return Ok(new csSanction().updateSanction(model.sanction_id, model.description, model.sanction_type, model.cost));
        }

        [HttpDelete]
        [Route("rest/api/deleteSanction")]
        public IHttpActionResult deleteSanction(requestDeleteSanction model)
        {
            return Ok(new csSanction().deleteSanction(model.sanction_id));
        }

        [HttpGet]
        [Route("rest/api/getSanctions")]
        public IHttpActionResult getSanctions()
        {
            return Ok(new csSanction().getSanctions());
        }

        [HttpGet]
        [Route("rest/api/getSanctionById")]
        public IHttpActionResult getSanctionById(string sanction_id)
        {
            return Ok(new csSanction().getSanctionById(sanction_id));
        }
    }
}