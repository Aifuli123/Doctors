
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Doctors.API.CustomerAttributes
{
    public class Test: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
          var collect=  filterContext.ActionDescriptor.GetCustomAttributes<SkipCheckLoginAttribute>();
            return;
        }
    }
}
