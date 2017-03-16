using Doctors.API.Controllers.BaseContolles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Doctors.API.Filters
{
    public class EncryptFilter : ActionFilterAttribute, IOrderFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var responseMessage = new HttpResponseMessage();
            
            var type = actionContext.ActionDescriptor.ReturnType;
            bool result = true;
            var baseController = actionContext.ControllerContext.Controller as EncryptBaseController;
             result=baseController.APPAuthorization;
            if (result)
            {
                result = baseController.SignSuccess;
            }

            if (!result)     
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, baseController.SIGN_ERROR);

            return;

        }

        public int Order { get { return 0; } }
    }
}