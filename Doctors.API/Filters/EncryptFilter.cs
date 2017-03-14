using Doctors.API.Controllers.BaseContolles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Doctors.API.Filters
{
    public class EncryptFilter : ActionFilterAttribute, IOrderFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var responseMessage = new HttpResponseMessage();
            
            var type = actionContext.ActionDescriptor.ReturnType;
            bool result = true;
            var baseController = actionContext.ControllerContext.Controller as EncryptBaseController;
             result=baseController.APPAuthorization;
            if (result)
            {
                //result = baseController.SignSuccess;
            }
             
          
            var cn = GlobalConfiguration.Configuration.Services.GetService(typeof(IContentNegotiator)) as IContentNegotiator;
            var cr = cn.Negotiate(type, actionContext.Request, GlobalConfiguration.Configuration.Formatters);
            responseMessage.Content = new ObjectContent(type,baseController.SIGN_ERROR, cr.Formatter);
            return;

        }

        public int Order { get { return 0; } }
    }
}