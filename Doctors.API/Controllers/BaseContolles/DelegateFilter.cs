using Doctors.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Doctors.API.Controllers.BaseContolles
{
    public class DelegateFilter : ActionFilterAttribute, IOrderFilter
    {
        public int Order { get { return 3; } }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string accountID = HttpContext.Current.Items["accountID"] as string;


        }
    }
}