using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Doctors.Model;
using Doctors.Services;
using Doctors.Model.BaseResult;
using Doctors.IServices;

namespace Doctors.Controllers
{
    public class ValuesController : ApiController
    {
        ISysUserInfo sysUserInfo;
        public  ValuesController(ISysUserInfo user)
        {
            sysUserInfo = user;
        }
        [HttpGet]
        public IHttpActionResult LogIn()
        {
           var Isok= sysUserInfo.LogIn("2", "22");
            BaseResult result = new BaseResult();
            if (Isok)
            {
                result.Result = Result.succeed;
                result.Message = "登陆成功！";
            }
            else
            {
                result.Result = Result.failure;
                result.Message = "登陆失败！";
            }
            return Json<BaseResult>(result);
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
