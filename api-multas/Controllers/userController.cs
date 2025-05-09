using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_multas.Models.User;
using static api_multas.Models.User.csEstructUser;

namespace api_multas.Controllers
{
    public class userController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertUser")]
        public IHttpActionResult insertUser(requestUser model){
            return Ok(new csUser().insertUser(model.full_name, model.username, model.password_hash, model.role_user));
        }

        [HttpPut]
        [Route("rest/api/updateUser")]
        public IHttpActionResult updateUser(requestUser model)
        {
            return Ok(new csUser().updateUser(model.user_id, model.full_name, model.username, model.password_hash, model.role_user));
        }

        [HttpDelete]
        [Route("rest/api/deleteUser")]
        public IHttpActionResult deleteUser(requestDeleteUser model)
        {
            return Ok(new csUser().deleteUser(model.user_id));
        }

        [HttpGet]
        [Route("rest/api/getUsers")]
        public IHttpActionResult getUsers()
        {
            return Ok(new csUser().getUsers());
        }

        [HttpGet]
        [Route("rest/api/getUserById")]
        public IHttpActionResult getUserById(string user_id)
        {
            return Ok(new csUser().getUserById(user_id));
        }


    }
}