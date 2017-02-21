
using Doctors.API.CustomerAttributes;
using Doctors.IServices;
using Doctors.Model.BaseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Doctors.API.Controllers
{
    [SkipCheckLoginAttribute]
    public class ValuesController : ApiController
    {
        ISysUserInfo sysUserInfo;
        public ValuesController(ISysUserInfo user)
        {
            sysUserInfo = user;
        }
        [HttpGet]
        [SkipCheckLogin]
        public IHttpActionResult LogIn()
        {
            var Isok = sysUserInfo.LogIn("2", "22");
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
      
    }
}
